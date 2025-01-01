using BlogPost.Application.Contracts.Post;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPosts;

public record GetPostsQuery() : IRequest<Result<IEnumerable<PostResponse>>>;