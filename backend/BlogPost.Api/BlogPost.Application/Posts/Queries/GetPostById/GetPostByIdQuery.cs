using BlogPost.Application.Contracts.Post;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Queries.GetPostById;

public sealed record GetPostByIdQuery(Guid Id) : IRequest<Result<DetailedPostResponse>>;