using BlogPost.Application.Contracts.Post;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Exceptions;
using BlogPost.Domain.Primitives;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;

namespace BlogPost.Application.Posts.Commands.CreatePost;

public class CreatePostHandler : IRequestHandler<CreatePostCommand, Result<int>>
{
    private readonly IPostRepository _postRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IValidator<CreatePostRequest> _validator;
    private readonly ILogger<CreatePostHandler> _logger;

    public CreatePostHandler(IPostRepository postRepository,
        ITagRepository tagRepository,
        IValidator<CreatePostRequest> validator,
        ILogger<CreatePostHandler> logger)
    {
        _postRepository = postRepository;
        _tagRepository = tagRepository;
        _validator = validator;
        _logger = logger;
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
        var selectedTags = (await _tagRepository.GetTagsByIdsAsync(post.TagIds)).ToList();

        var entity = post.ToEntity();
        entity.Tags = selectedTags;

        _logger.LogDebug("Creating post Entity to the database...");
        var entityId = await _postRepository.CreateAsync(entity);

        _logger.LogInformation("Post created successfully with ID: {Id}", entityId);

        return Result<int>.Success(entityId);
    }
}