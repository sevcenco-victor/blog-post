using BlogPost.Application.Contracts.Post;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Posts;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetLatestPosts;

public sealed class GetLatestPostsHandler : IRequestHandler<GetLatestPostsQuery, Result<IEnumerable<PostResponse>>>
{
    private readonly IPostRepository _postRepository;

    public GetLatestPostsHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Result<IEnumerable<PostResponse>>> Handle(GetLatestPostsQuery request,
        CancellationToken cancellationToken)
    {
        var num = request.Num;
        if (num != null && num <= 0)
        {
            return Result<IEnumerable<PostResponse>>.Failure(Error.Failure("Post.GetLatestPosts",
                "Number must be greater than 0"));
        }

        var posts = await _postRepository.GetLatestAsync(request.Num, cancellationToken);
        var mappedPosts = posts.Select(p => p.ToPostResponseDto());

        return Result<IEnumerable<PostResponse>>.Success(mappedPosts);
    }
}