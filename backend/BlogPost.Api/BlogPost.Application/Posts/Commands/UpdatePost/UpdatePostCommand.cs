using BlogPost.Application.Contracts.Post;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Commands.UpdatePost;

public sealed record UpdatePostCommand(Guid EntityId, UpdatePostRequest Post) : IRequest<Result>;