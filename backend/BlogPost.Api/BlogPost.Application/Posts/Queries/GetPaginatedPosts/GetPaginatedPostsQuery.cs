using BlogPost.Application.Posts.Common;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPaginatedPosts;

public sealed record GetPaginatedPostsQuery(Guid? UserId, PaginationFilter PaginationFilter)
    : IRequest<Result<IEnumerable<PostResponse>>>;