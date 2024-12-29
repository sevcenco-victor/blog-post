using BlogPost.Application.Contracts.Post;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Entities;
using FluentValidation;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Posts.Commands.CreatePost;

public class CreatePostHandler : IRequestHandler<CreatePostCommand, Result<int>>
{
    private readonly IPostRepository _postRepository;
    private readonly ITagRepository _tagRepository;
    private readonly IValidator<CreatePostRequest> _validator;

    public CreatePostHandler(IPostRepository postRepository, ITagRepository tagRepository,
        IValidator<CreatePostRequest> validator)
    {
        _postRepository = postRepository;
        _tagRepository = tagRepository;
        _validator = validator;
    }


    public async Task<Result<int>> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request.Post, cancellationToken);
        if (!validationResult.IsValid)
        {
            var error = new ValidationException("Invalid post", validationResult.Errors);
            return new Result<int>(error);
        }

        var post = request.Post;
        var selectedTags = (await _tagRepository.GetTagsByIdsAsync(post.TagIds)).ToList();

        var entity = post.ToEntity();
        entity.Tags = selectedTags;

        var entityId = await _postRepository.CreateAsync(entity);

        return new Result<int>(entityId);
    }
}