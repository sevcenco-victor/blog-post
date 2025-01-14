using System.Security.Claims;
using BlogPost.Application.Abstractions;
using BlogPost.Application.Auth.Common;
using BlogPost.Application.Users.Queries.GetById;
using BlogPost.Domain.Common;
using BlogPost.Domain.Primitives;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BlogPost.Infrastructure.Services;

public class AuthService : IAuthService
{

    private readonly IJwtTokenService _jwtTokenService;
    private readonly IMediator _mediator;

    public AuthService(IMediator mediator, IJwtTokenService jwtTokenService)
    {
        _mediator = mediator;
        _jwtTokenService = jwtTokenService;
    }

    public void SetTokensInsideCookie(TokenResponse tokens, HttpContext httpContext)
    {
        httpContext.Response.Cookies.Append("accessToken", tokens.AccessToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            IsEssential = true,
            Expires = DateTime.UtcNow.AddMinutes(15)
        });
        httpContext.Response.Cookies.Append("refreshToken", tokens.RefreshToken, new CookieOptions
        {
            HttpOnly = true,
            Secure = true,
            SameSite = SameSiteMode.None,
            IsEssential = true,
            Expires = DateTime.UtcNow.AddDays(7)
        });
    }

    public async Task<Result<string>> RenewAccessToken(TokenResponse tokens, CancellationToken cancellationToken)
    {
        var (accessToken, refreshToken) = tokens;
        
        if (string.IsNullOrEmpty(refreshToken) || string.IsNullOrEmpty(accessToken))
        {
            return Result<string>.Failure(AuthErrors.UnAuthorized());
        }
        
        var claimsPrincipal = _jwtTokenService.GetPrincipalFromExpiredToken(accessToken);
        
        var nameIdentifier = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        int.TryParse(nameIdentifier, out var userId);
        
        var result = await _mediator.Send(new GetUserByIdQuery(userId), cancellationToken);
        var user = result.Value;
        
        if (user.RefreshToken != refreshToken
            || user.RefreshTokenExpiry <= DateTime.UtcNow)
        {
            return Result<string>.Failure(AuthErrors.UnAuthorized());
        }
        
        var newToken = _jwtTokenService.GenerateToken(user);
        
        return Result<string>.Success(newToken);
    }
}