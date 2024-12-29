using BlogPost.Contracts.Post;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPostById;

public sealed record GetPostByIdQuery(int Id) : IRequest<Result<PostResponse>>;