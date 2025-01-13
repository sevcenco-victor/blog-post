using BlogPost.Application.Auth.Common;
using BlogPost.Application.Contracts.Auth;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Auth.Commands.Login;

public sealed record LoginUserCommand(UserLoginRequest Data): IRequest<Result<TokenResponse>>;
