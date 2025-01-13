using BlogPost.Application.Auth.Common;
using BlogPost.Application.Contracts.Auth;
using BlogPost.Application.Contracts.User;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Auth.Commands.Register;

public sealed record RegisterUserCommand(CreateUserRequest Request) : IRequest<Result<TokenResponse>>;