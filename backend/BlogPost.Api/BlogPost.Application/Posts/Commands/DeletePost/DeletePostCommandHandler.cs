using BlogPost.Domain.Posts;
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

        var deleted = await _postRepository.DeleteAsync(postId, cancellationToken);

        return deleted
            ? Result.Success()
            : Result.Failure(PostErrors.NotFoundById(postId));
    }
}