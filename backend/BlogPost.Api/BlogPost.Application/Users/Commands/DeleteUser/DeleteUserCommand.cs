using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Users.Commands.DeleteUser;

public sealed record DeleteUserCommand(Guid UserId) : IRequest<Result<bool>>;