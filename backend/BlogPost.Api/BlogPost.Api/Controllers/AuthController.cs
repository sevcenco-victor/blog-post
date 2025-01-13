using BlogPost.Api.Extensions;
using BlogPost.Application.Auth.Commands.Login;
using BlogPost.Application.Auth.Commands.Register;
using BlogPost.Application.Auth.Queries.RefreshToken;
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

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest request, CancellationToken cancellationToken)
    {
        var command = new LoginUserCommand(request);
        var result = await _mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: token => Ok(token),
            onFailure: _ => result.ToProblemDetails()
        );
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var command = new RegisterUserCommand(request);
        var result = await _mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: token => Ok(token),
            onFailure: _ => result.ToProblemDetails()
        );
    }

    [HttpGet("refreshToken")]
    public async Task<IActionResult> RefreshToken([FromQuery] RefreshTokenRequest request,
        CancellationToken cancellationToken)
    {
        var command = new RefreshTokenQuery(request);
        var result = await _mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: token => Ok(token),
            onFailure: _ => result.ToProblemDetails()
        );
    }
}