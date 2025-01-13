using BlogPost.Application.Tags.Common;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Tags.Queries.GetTagById;

public sealed record GetTagByIdQuery(int Id) : IRequest<Result<TagResponse>>;