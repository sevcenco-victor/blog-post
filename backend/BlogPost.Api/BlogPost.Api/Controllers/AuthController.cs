using BlogPost.Api.Extensions;
using BlogPost.Application.Abstractions;
using BlogPost.Application.Auth.Commands.Login;
using BlogPost.Application.Auth.Commands.Register;
using BlogPost.Application.Auth.Common;
using BlogPost.Application.Contracts.Auth;
using BlogPost.Application.Contracts.User;
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

        _authService.SetTokensInsideCookie(result.Value, HttpContext);

        return result.Match<IActionResult>(
            onSuccess: _ => Ok(),
            onFailure: _ => result.ToProblemDetails()
        );
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest request,
        CancellationToken cancellationToken)
    {
        var command = new RegisterUserCommand(request);
        var result = await _mediator.Send(command, cancellationToken);

        if (result.IsSuccess)
        {
            var (userId, tokens) = result.Value;

            _authService.SetTokensInsideCookie(tokens, HttpContext);
            return CreatedAtRoute("GetUserById", new { id = userId }, null);
        }

        return result.ToProblemDetails();
    }

    [HttpGet("refreshToken")]
    public async Task<IActionResult> RefreshToken(CancellationToken cancellationToken)
    {
        HttpContext.Request.Cookies.TryGetValue("accessToken", out var accessToken);
        HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);

        if (string.IsNullOrEmpty(accessToken)
            || string.IsNullOrEmpty(refreshToken))
        {
            return Unauthorized();
        }

        var newTokenResponse =
            await _authService.RenewAccessToken(new TokenResponse(accessToken, refreshToken), cancellationToken);

        if (newTokenResponse.IsSuccess)
        {
            _authService.SetTokensInsideCookie(new TokenResponse(newTokenResponse.Value, refreshToken), HttpContext);
            return Ok();
        }

        return newTokenResponse.ToProblemDetails();
    }
}