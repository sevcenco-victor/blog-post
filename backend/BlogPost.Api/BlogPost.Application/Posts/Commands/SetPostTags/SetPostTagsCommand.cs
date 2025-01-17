using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Posts.Commands.SetPostTags;

public sealed record SetPostTagsCommand(Guid PostId, IEnumerable<Guid> TagIds) : IRequest<Result>;