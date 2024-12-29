using BlogPost.Application.Mapper;
using BlogPost.Contracts.Post;
using BlogPost.Domain.Abstractions;
using LanguageExt.Common;
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

        return mappedPosts.ToList();
    }
}