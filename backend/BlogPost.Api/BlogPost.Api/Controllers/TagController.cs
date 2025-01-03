using BlogPost.Api.Extensions;
using BlogPost.Application.Contracts.Tag;
using BlogPost.Application.Tags.Commands.CreateTag;
using BlogPost.Application.Tags.Commands.DeleteTag;
using BlogPost.Application.Tags.Commands.UpdateTag;
using BlogPost.Application.Tags.Queries.GetTagById;
using BlogPost.Application.Tags.Queries.GetTags;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TagController : ControllerBase
{
    private readonly IMediator _mediator;

    public TagController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateTagRequest request)
    {
        var command = new CreateTagCommand(request);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            onSuccess: entityId => CreatedAtAction(nameof(Get), new { id = entityId }, entityId),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetTagByIdQuery(id);
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            onSuccess: tag => Ok(tag),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetTagsQuery();
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            onSuccess: tagList => Ok(tagList),
            onFailure: _ => result.ToProblemDetails());
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateTagRequest request)
    {
        var command = new UpdateTagCommand(id, request);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            onSuccess: () => NoContent(),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteTagCommand(id);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            onSuccess: () => NoContent(),
            onFailure: _ => result.ToProblemDetails());
    }
}