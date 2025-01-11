using BlogPost.Application.Contracts.Post;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPaginatedPosts;

public sealed record GetPaginatedPostsQuery(PaginationFilter PaginationFilter)
    : IRequest<Result<IEnumerable<PostResponse>>>;