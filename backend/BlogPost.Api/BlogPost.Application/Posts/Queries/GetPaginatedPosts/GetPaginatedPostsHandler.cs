using BlogPost.Application.Mapper;
using BlogPost.Contracts.Post;
using BlogPost.Domain.Abstractions;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPaginatedPosts;

public class GetPaginatedPostsHandler : IRequestHandler<GetPaginatedPostsQuery, Result<IEnumerable<PostResponse>>>
{
    private readonly IPostRepository _postRepository;

    public GetPaginatedPostsHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<Result<IEnumerable<PostResponse>>> Handle(GetPaginatedPostsQuery request,
        CancellationToken cancellationToken)
    {
        var entities = await _postRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);
        var mappedPosts = entities.Select(p => p.ToPostResponseDto());

        return new Result<IEnumerable<PostResponse>>(mappedPosts);
    }
}