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
        var (pageNumber, pageSize, title, tagIds) = request.PaginationFilter;

        if (pageNumber <= 0 || pageSize <= 0)
        {
            return Result<IEnumerable<PostResponse>>.Failure(Error.Failure("Post.Pagination",
                "PageNumber and PageSize must be greater than 0"));
        }

        var entities = await _postRepository.GetPaginatedAsync(pageNumber, pageSize, title, tagIds);
        var mappedPosts = entities.Select(p => p.ToPostResponseDto());

        return Result<IEnumerable<PostResponse>>.Success(mappedPosts);
    }
}