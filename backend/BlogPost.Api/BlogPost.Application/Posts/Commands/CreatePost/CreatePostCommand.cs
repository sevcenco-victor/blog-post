using BlogPost.Application.Contracts.Post;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Posts.Commands.CreatePost;

public sealed record CreatePostCommand(CreatePostRequest Post) : IRequest<Result<int>>;