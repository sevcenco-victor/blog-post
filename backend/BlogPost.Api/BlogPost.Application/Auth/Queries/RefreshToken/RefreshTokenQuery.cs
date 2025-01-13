using BlogPost.Application.Contracts.Auth;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Auth.Queries.RefreshToken;

public sealed record RefreshTokenQuery(RefreshTokenRequest Data) : IRequest<Result<string>>;