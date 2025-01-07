using BlogPost.Application.Contracts.Post;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetLatestPosts;

public record GetLatestPostsQuery(int? Num) : IRequest<Result<IEnumerable<PostResponse>>>;