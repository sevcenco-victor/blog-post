using BlogPost.Application.Contracts.Blog;
using BlogPost.Application.Contracts.Post;
using BlogPost.Application.Posts.Commands.CreatePost;
using BlogPost.Application.Posts.Commands.DeletePost;
using BlogPost.Application.Posts.Commands.SetPostTags;
using BlogPost.Application.Posts.Commands.UpdatePost;
using BlogPost.Application.Posts.Queries.GetPostById;
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
            success => Ok(success),
            error => BadRequest(new { Error = error.Message }));
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var command = new GetPostByIdQuery(id);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success => Ok(success),
            error => BadRequest(new
            {
                Errors = error.Message
            }));
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetPostsQuery();
        var posts = await _mediator.Send(query);

        return posts.Match<IActionResult>(
            success => Ok(success),
            error => StatusCode(500, new { Message = "Internal server error", Errors = error.Message }));
    }

    [HttpPut("{postId:int}")]
    public async Task<IActionResult> Update(int postId, [FromBody] UpdatePostRequest request)
    {
        var command = new UpdatePostCommand(postId, request);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success => Ok(success),
            error => BadRequest(new { Errors = error.Message })
        );
    }

    [HttpPatch("set-tags/{id:int}")]
    public async Task<IActionResult> AddTags(int id, [FromBody] IEnumerable<int> tagIds)
    {
        var command = new SetPostTagsCommand(id, tagIds);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success => Ok(),
            error => BadRequest(new { Errors = error.Message }));
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeletePostCommand(id);
        var result = await _mediator.Send(command);

        return result.Match<IActionResult>(
            success => NoContent(),
            error => BadRequest(new { Errors = error.Message }));
    }
}