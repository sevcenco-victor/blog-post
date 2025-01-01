using BlogPost.Application.Contracts.Post;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPaginatedPosts;

public record GetPaginatedPostsQuery(int PageSize, int PageNumber) : IRequest<Result<IEnumerable<PostResponse>>>;