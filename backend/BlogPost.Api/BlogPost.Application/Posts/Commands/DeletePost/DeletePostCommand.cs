using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Posts.Commands.DeletePost;

public sealed record DeletePostCommand(int Id) : IRequest<Result<bool>>;