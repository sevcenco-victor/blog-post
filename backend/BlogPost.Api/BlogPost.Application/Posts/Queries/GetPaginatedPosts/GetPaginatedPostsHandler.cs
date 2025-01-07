using BlogPost.Application.Contracts.Post;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Primitives;
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
        if (request.PageNumber <= 0 || request.PageSize <= 0)
        {
            return Result<IEnumerable<PostResponse>>.Failure(Error.Failure("Post.Pagination",
                "PageNumber and PageSize must be greater than 0"));
        }

        var entities = await _postRepository.GetPaginatedAsync(request.PageNumber, request.PageSize);
        var mappedPosts = entities.Select(p => p.ToPostResponseDto());

        return Result<IEnumerable<PostResponse>>.Success(mappedPosts);
    }
}