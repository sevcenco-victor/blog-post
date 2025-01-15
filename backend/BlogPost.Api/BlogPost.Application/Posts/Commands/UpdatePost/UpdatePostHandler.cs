using BlogPost.Application.Mapper;
using BlogPost.Domain.Exceptions;
using BlogPost.Domain.Posts;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Commands.UpdatePost;

public sealed class UpdatePostHandler : IRequestHandler<UpdatePostCommand, Result>
{
    private readonly IPostRepository _postRepository;

    public UpdatePostHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Result> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
    {
        var postId = request.EntityId;

        var existingPost = await _postRepository.GetByIdAsync(postId, cancellationToken);
        if (existingPost == null)
        {
            return Result.Failure(PostErrors.NotFoundById(postId));
        }

        var mappedPost = request.Post.ToEntity();
        mappedPost.Id = existingPost.Id;

        await _postRepository.UpdateAsync(mappedPost, cancellationToken);

        return Result.Success();
    }
}