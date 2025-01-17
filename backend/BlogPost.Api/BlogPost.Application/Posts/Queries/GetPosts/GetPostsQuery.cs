using BlogPost.Application.Posts.Common;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPosts;

public record GetPostsQuery() : IRequest<Result<IEnumerable<PostResponse>>>;