using BlogPost.Application.Contracts.Blog;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Posts.Commands.UpdatePost;

public sealed record UpdatePostCommand(int EntityId, UpdatePostRequest Post) : IRequest<Result<bool>>;