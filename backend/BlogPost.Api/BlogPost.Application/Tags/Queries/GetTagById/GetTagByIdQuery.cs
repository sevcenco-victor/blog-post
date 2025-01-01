using BlogPost.Application.Contracts.Tag;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Tags.Queries.GetTagById;

public sealed record GetTagByIdQuery(int Id): IRequest<Result<TagResponse>>;