using BlogPost.Application.Contracts.User;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Users.Commands.CreateUser;

public sealed record CreateUserCommand(CreateUserRequest Request) : IRequest<Result<int>>;