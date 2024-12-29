using BlogPost.Application.Contracts.Tag;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Tags.Queries.GetTags;

public class GetTagsHandler : IRequestHandler<GetTagsQuery, Result<IEnumerable<TagResponse>>>
{
    private readonly ITagRepository _tagRepository;

    public GetTagsHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Result<IEnumerable<TagResponse>>> Handle(GetTagsQuery request,
        CancellationToken cancellationToken)
    {
        var tags = await _tagRepository.GetAllAsync();
        var mappedTags = tags.Select(t => t.ToTagResponse());

        return new Result<IEnumerable<TagResponse>>(mappedTags);
    }
}