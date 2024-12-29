using BlogPost.Application.Exceptions;
using BlogPost.Domain.Abstractions;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Posts.Commands.DeletePost;

public sealed class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, Result<bool>>
{
    private readonly IPostRepository _postRepository;

    public DeletePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Result<bool>> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _postRepository.DeleteAsync(request.Id);
        if (!deleted)
        {
            var error = new PostNotFoundException($"Post with id: {request.Id} was not found");
            return new Result<bool>(error);
        }

        return new Result<bool>(true);
    }
}