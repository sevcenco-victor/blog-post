using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Exceptions;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Commands.DeletePost;

public sealed class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Result>
{
    private readonly IPostRepository _postRepository;

    public DeletePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Result> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var postId = request.Id;

        var deleted = await _postRepository.DeleteAsync(postId);
        if (!deleted)
        {
            return Result.Failure(PostErrors.NotFound(postId));
        }

        return Result.Success();
    }
}