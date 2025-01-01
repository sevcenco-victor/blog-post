using BlogPost.Application.Contracts.Post;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Exceptions;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPostById;

public sealed class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, Result<PostResponse>>
{
    private readonly IPostRepository _postRepository;

    public GetPostByIdHandler(IPostRepository postRepository) => _postRepository = postRepository;

    public async Task<Result<PostResponse>> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
    {
        var postId = query.Id;
        var post = await _postRepository.GetByIdAsync(postId);

        if (post == null)
        {
            return Result<PostResponse>.Failure(PostErrors.NotFound(postId));
        }

        return Result<PostResponse>.Success(post.ToPostResponseDto());
    }
}