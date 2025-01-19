using BlogPost.Api.Extensions;
using BlogPost.Application.Contracts.Post;
using BlogPost.Application.Posts.Commands.CreatePost;
using BlogPost.Application.Posts.Commands.DeletePost;
using BlogPost.Application.Posts.Commands.SetPostTags;
using BlogPost.Application.Posts.Commands.UpdatePost;
using BlogPost.Application.Posts.Common;
using BlogPost.Application.Posts.Queries.GetLatestPosts;
using BlogPost.Application.Posts.Queries.GetPaginatedPosts;
using BlogPost.Application.Posts.Queries.GetPostById;
using BlogPost.Application.Posts.Queries.GetPostQty;
using BlogPost.Application.Posts.Queries.GetPosts;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;

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

    [Authorize(Roles = "User")]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePostRequest request, CancellationToken cancellationToken)
    {
        var command = new CreatePostCommand(request);
        var result = await _mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: postId => Ok(postId),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id, CancellationToken cancellationToken)
    {
        var command = new GetPostByIdQuery(id);
        var result = await _mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: post => Ok(post),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var query = new GetPostsQuery();
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: postList => Ok(postList),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpGet("qty")]
    public async Task<IActionResult> GetQuantity(CancellationToken cancellationToken)
    {
        var query = new GetPostQtyQuery();
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: qty => Ok(qty),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetUserPosts(Guid userId, [FromQuery] PaginationFilter paginationFilter,
        CancellationToken cancellationToken)
    {
        var query = new GetPaginatedPostsQuery(userId, paginationFilter);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: posts => Ok(posts),
            onFailure: _ => result.ToProblemDetails()
        );
    }

    [HttpGet("paginated")]
    public async Task<IActionResult> GetAllPaginated([FromQuery] PaginationFilter paginationFilter,
        CancellationToken cancellationToken)
    {
        var query = new GetPaginatedPostsQuery(null, paginationFilter);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: postList => Ok(postList),
            onFailure: _ => result.ToProblemDetails());
    }

    [HttpGet("latest")]
    public async Task<IActionResult> GetLatest(int? num, CancellationToken cancellationToken)
    {
        var query = new GetLatestPostsQuery(num);
        var result = await _mediator.Send(query, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: postList => Ok(postList),
            onFailure: _ => result.ToProblemDetails());
    }

    [Authorize(Roles = "User")]
    [HttpPut("{postId:guid}")]
    public async Task<IActionResult> Update(Guid postId, [FromBody] UpdatePostRequest request,
        CancellationToken cancellationToken)
    {
        var command = new UpdatePostCommand(postId, request);
        var result = await _mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: () => NoContent(),
            _ => result.ToProblemDetails());
    }

    [Authorize(Roles = "User")]
    [HttpPatch("set-tags/{id:guid}")]
    public async Task<IActionResult> AddTags(Guid id, [FromBody] IEnumerable<Guid> tagIds,
        CancellationToken cancellationToken)
    {
        var command = new SetPostTagsCommand(id, tagIds);
        var result = await _mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: () => NoContent(),
            onFailure: _ => result.ToProblemDetails());
    }

    [Authorize(Roles = "Admin,User")]
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var command = new DeletePostCommand(id);
        var result = await _mediator.Send(command, cancellationToken);

        return result.Match<IActionResult>(
            onSuccess: () => NoContent(),
            onFailure: _ => result.ToProblemDetails());
    }
}