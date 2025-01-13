using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Users.Commands.UpdateUser;

public sealed record UpdateUserCommand(UpdateUserRequest Data) : IRequest<Result<bool>>;