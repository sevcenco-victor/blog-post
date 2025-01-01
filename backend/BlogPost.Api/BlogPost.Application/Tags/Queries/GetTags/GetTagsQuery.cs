using BlogPost.Application.Contracts.Tag;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Tags.Queries.GetTags;

public sealed record GetTagsQuery() : IRequest<Result<IEnumerable<TagResponse>>>;