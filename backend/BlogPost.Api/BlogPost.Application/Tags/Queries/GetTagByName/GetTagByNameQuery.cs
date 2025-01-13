using BlogPost.Application.Tags.Common;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Tags.Queries.GetTagByName;

public sealed record GetTagByNameQuery(string Name) : IRequest<Result<TagResponse>>;