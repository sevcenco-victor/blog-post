using BlogPost.Application.Contracts.Tag;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Tags.Commands.CreateTag;

public sealed record CreateTagCommand(CreateTagRequest Entity) : IRequest<Result<int>>;