using BlogPost.Contracts.Post;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPosts;

public record GetPostsQuery() : IRequest<Result<IEnumerable<PostResponse>>>;