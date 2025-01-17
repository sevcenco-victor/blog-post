using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Tags.Commands.CreateTag;

public sealed record CreateTagCommand(CreateTagRequest Entity) : IRequest<Result<Guid>>;