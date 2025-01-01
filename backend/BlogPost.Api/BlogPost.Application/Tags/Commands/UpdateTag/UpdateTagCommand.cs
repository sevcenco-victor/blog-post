using BlogPost.Application.Contracts.Tag;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Tags.Commands.UpdateTag;

public sealed record UpdateTagCommand(int EntityId, UpdateTagRequest Entity) : IRequest<Result>;