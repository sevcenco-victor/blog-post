using BlogPost.Application.Contracts.Tag;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Tags.Commands.UpdateTag;

public sealed record UpdateTagCommand(int EntityId, UpdateTagRequest Entity) : IRequest<Result<bool>>;