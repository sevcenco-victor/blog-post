using BlogPost.Application.Abstractions;
using BlogPost.Application.Common;
using BlogPost.Application.Contracts.Post;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Exceptions;
using BlogPost.Domain.Primitives;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BlogPost.Application.Posts.Commands.CreatePost;

public sealed class CreatePostHandler : IRequestHandler<CreatePostCommand, Result<int>>
{
    private readonly IPostRepository _postRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IValidator<CreatePostRequest> _validator;
    private readonly ILogger<CreatePostHandler> _logger;
    private readonly ICloudStorageService _cloudStorageService;
    private readonly IFileFactory _fileFactory;

    public CreatePostHandler(IPostRepository postRepository,
        ITagRepository tagRepository,
        IValidator<CreatePostRequest> validator,
        ILogger<CreatePostHandler> logger, ICloudStorageService cloudStorageService, IFileFactory fileFactory)
    {
        _postRepository = postRepository;
        _tagRepository = tagRepository;
        _validator = validator;
        _logger = logger;
        _cloudStorageService = cloudStorageService;
        _fileFactory = fileFactory;
    }


    public async Task<Result<int>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Post, cancellationToken);

        if (!validationResult.IsValid)
        {
            var error = new ValidationException("Invalid post", validationResult.Errors);

            _logger.LogWarning("Validation failed for Post with Title {Title} with Errors: {Errors}",
                request.Post.Title, error.Errors);

            return Result<int>.Failure(PostErrors.ValidationError(error.Errors.ToString()));
        }

        var post = request.Post;
        var selectedTags = (await _tagRepository.GetTagsByIdsAsync(post.TagIds, cancellationToken)).ToList();

        var markdownFileName = FileNameGenerator.GenerateMarkDownFileName(post.Title);
        var markdownFile = _fileFactory.CreateInMemoryFile(post.MarkdownFileContent, markdownFileName);

        await _cloudStorageService.UploadFileAsync(markdownFile, cancellationToken);

        var mappedEntity = post.ToEntity(selectedTags, markdownFileName);
        var createdEntityId = await _postRepository.CreateAsync(mappedEntity, cancellationToken);

        _logger.LogInformation("Post created successfully with ID: {Id}", createdEntityId);
        return Result<int>.Success(createdEntityId);
    }
}