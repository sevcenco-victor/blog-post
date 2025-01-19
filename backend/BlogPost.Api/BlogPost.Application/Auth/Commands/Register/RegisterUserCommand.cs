using BlogPost.Application.Users.Commands.CreateUser;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Auth.Commands.Register;

public sealed record RegisterUserCommand(CreateUserRequest Request) : IRequest<Result<RegisterUserResponse>>;