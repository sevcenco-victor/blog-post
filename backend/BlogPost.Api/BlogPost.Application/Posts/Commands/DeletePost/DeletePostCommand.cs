using MediatR;
using BlogPost.Domain.Primitives;

namespace BlogPost.Application.Posts.Commands.DeletePost;

public sealed record DeletePostCommand(int Id) : IRequest<Result>;