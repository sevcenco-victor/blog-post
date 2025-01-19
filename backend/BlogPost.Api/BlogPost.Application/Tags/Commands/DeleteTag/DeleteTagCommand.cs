using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Tags.Commands.DeleteTag;

public sealed record DeleteTagCommand(Guid Id) : IRequest<Result>;