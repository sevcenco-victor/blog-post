using BlogPost.Application.Contracts.Tag;
using BlogPost.Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Tags.Queries.GetTags;

public sealed record GetTagsQuery() : IRequest<Result<IEnumerable<TagResponse>>>;