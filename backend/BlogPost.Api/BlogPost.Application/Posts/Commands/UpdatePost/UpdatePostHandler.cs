using BlogPost.Application.Exceptions;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Posts.Commands.UpdatePost;

public class UpdatePostHandler : IRequestHandler<UpdatePostCommand, Result<bool>>
{
    private readonly IPostRepository _postRepository;

    public UpdatePostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Result<bool>> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var existingPost = await _postRepository.GetByIdAsync(request.EntityId);
        if (existingPost == null)
        {
            var error = new PostNotFoundException($"Post with id {request.EntityId} not found");
            return new Result<bool>(error);
        }

        var mappedPost = request.Post.ToEntity();
        mappedPost.Id = existingPost.Id;

        await _postRepository.UpdateAsync(mappedPost);

        return new Result<bool>(true);
    }
}