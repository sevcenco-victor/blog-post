using BlogPost.Application.Contracts.Tag;
using BlogPost.Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Tags.Queries.GetTagByName;

public sealed record GetTagByNameQuery(string Name) : IRequest<Result<TagResponse>>;
