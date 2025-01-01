using BlogPost.Application.Contracts.Post;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPosts;

public class GetPostsHandler : IRequestHandler<GetPostsQuery, Result<IEnumerable<PostResponse>>>
{
    private readonly IPostRepository _postRepository;

    public GetPostsHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Result<IEnumerable<PostResponse>>> Handle(GetPostsQuery request,
        CancellationToken cancellationToken)
    {
        var posts = await _postRepository.GetAllAsync();
        var mappedPosts = posts.Select(p => p.ToPostResponseDto());

        return Result<IEnumerable<PostResponse>>.Success(mappedPosts.ToList());
    }
}