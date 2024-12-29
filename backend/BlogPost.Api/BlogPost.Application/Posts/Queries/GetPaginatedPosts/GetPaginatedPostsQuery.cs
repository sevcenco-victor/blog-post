using BlogPost.Contracts.Post;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPaginatedPosts;

public record GetPaginatedPostsQuery(int PageSize, int PageNumber) : IRequest<Result<IEnumerable<PostResponse>>>;