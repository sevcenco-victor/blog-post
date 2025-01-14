using BlogPost.Api.Extensions;
using BlogPost.Application.Users.Queries.GetAll;
using BlogPost.Application.Users.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetAllUsersQuery();
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: users => Ok(users),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpGet("{id:int}", Name = "GetUserById")]
    public async Task<IActionResult> GetById(int id, CancellationToken cancellationToken)
    {
        var query = new GetUserByIdQuery(id);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: user => Ok(user),
            onFailure: _ => result.ToProblemDetails());
    }
}