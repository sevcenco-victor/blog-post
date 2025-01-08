using BlogPost.Api.Extensions;
using BlogPost.Application.Contracts.Post;
using BlogPost.Application.Posts.Commands.CreatePost;
using BlogPost.Application.Posts.Commands.DeletePost;
using BlogPost.Application.Posts.Commands.SetPostTags;
using BlogPost.Application.Posts.Commands.UpdatePost;
using BlogPost.Application.Posts.Queries.GetLatestPosts;
using BlogPost.Application.Posts.Queries.GetPaginatedPosts;
using BlogPost.Application.Posts.Queries.GetPostById;
using BlogPost.Application.Posts.Queries.GetPostQty;
using BlogPost.Application.Posts.Queries.GetPosts;
using Microsoft.AspNetCore.Mvc;
using MediatR;

namespace BlogPost.Api.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class PostController : ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostRequest request)
    {
        var command = new CreatePostCommand(request);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            onSuccess: postId => Ok(postId),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var command = new GetPostByIdQuery(id);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            onSuccess: post => Ok(post),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetPostsQuery();
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            onSuccess: postList => Ok(postList),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpGet("qty")]
    public async Task<IActionResult> GetQuantity()
    {
        var query = new GetPostQtyQuery();
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            onSuccess: qty => Ok(qty),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpGet("paginated")]
    public async Task<IActionResult> GetAllPaginated(int pageSize, int pageNumber)
    {
        var query = new GetPaginatedPostsQuery(pageSize, pageNumber);
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            onSuccess: postList => Ok(postList),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpGet("latest")]
    public async Task<IActionResult> GetLatest(int? num)
    {
        var query = new GetLatestPostsQuery(num);
        var result = await _mediator.Send(query);

        return result.Match<IActionResult>(
            onSuccess: postList => Ok(postList),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpPut("{postId:int}")]
    public async Task<IActionResult> Update(int postId, [FromBody] UpdatePostRequest request)
    {
        var command = new UpdatePostCommand(postId, request);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            onSuccess: () => NoContent(),
            _ => result.ToProblemDetails());
    }

    [HttpPatch("set-tags/{id:int}")]
    public async Task<IActionResult> AddTags(int id, [FromBody] IEnumerable<int> tagIds)
    {
        var command = new SetPostTagsCommand(id, tagIds);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            onSuccess: () => NoContent(),
            onFailure: _ => result.ToProblemDetails());
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeletePostCommand(id);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            onSuccess: () => NoContent(),
            onFailure: _ => result.ToProblemDetails());
    }
}