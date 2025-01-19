using BlogPost.Api.Extensions;
using BlogPost.Application.Abstractions;
using BlogPost.Application.Auth.Commands.Login;
using BlogPost.Application.Auth.Commands.Register;
using BlogPost.Application.Auth.Common;
using BlogPost.Application.Contracts.Auth;
using BlogPost.Application.Users.Commands.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IAuthService _authService;

    public AuthController(IMediator mediator, IAuthService authService)
    {
        _mediator = mediator;
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest request,
        CancellationToken cancellationToken)
    {
        var command = new LoginUserCommand(request);
        var result = await _mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: _ =>
            {
                _authService.SetRefreshTokenInsideCookie(result.Value.RefreshToken, HttpContext);
                return Ok(result.Value.AccessToken);
            },
            onFailure: _ => result.ToProblemDetails()
        );
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = new RegisterUserCommand(request);
        var result = await _mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: _ =>
            {
                var (userId, tokens) = result.Value;

                _authService.SetRefreshTokenInsideCookie(tokens.RefreshToken, HttpContext);
                return CreatedAtRoute("GetUserById", new { id = userId }, null);
            },
            onFailure: _ => result.ToProblemDetails()
        );
    }

    [HttpPost("refreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request,
        CancellationToken cancellationToken)
    {
        HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);
        var accessToken = request.AccessToken;

        if (string.IsNullOrEmpty(accessToken)
            || string.IsNullOrEmpty(refreshToken))
        {
            return Unauthorized();
        }

        var result =
            await _authService.RenewAccessToken(new TokenResponse(accessToken, refreshToken), cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: token => Ok(token),
            onFailure: _ => result.ToProblemDetails());
    }
}