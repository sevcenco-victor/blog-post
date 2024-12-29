using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Posts.Commands.SetPostTags;

public sealed record SetPostTagsCommand(int PostId, IEnumerable<int> TagIds) : IRequest<Result<bool>>;