using BlogPost.Application.Contracts.Tag;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Tags.Queries.GetTagById;

public sealed record GetTagByIdQuery(int Id): IRequest<Result<TagResponse>>;