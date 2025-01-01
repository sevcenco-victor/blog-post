using BlogPost.Application.Contracts.Post;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Commands.CreatePost;

public sealed record CreatePostCommand(CreatePostRequest Post) : IRequest<Result<int>>;