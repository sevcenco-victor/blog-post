using BlogPost.Application.Auth.Common;
using BlogPost.Domain.Primitives;
using Microsoft.AspNetCore.Http;

namespace BlogPost.Application.Abstractions;

public interface IAuthService
{
    void SetTokensInsideCookie(TokenResponse tokens, HttpContext httpContext);
    Task<Result<string>> RenewAccessToken(TokenResponse tokens, CancellationToken cancellationToken);
}