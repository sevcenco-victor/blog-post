using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Commands.SetPostTags;

public sealed record SetPostTagsCommand(int PostId, IEnumerable<int> TagIds) : IRequest<Result>;