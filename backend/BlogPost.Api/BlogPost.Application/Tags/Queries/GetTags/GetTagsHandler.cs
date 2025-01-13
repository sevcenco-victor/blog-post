using BlogPost.Application.Contracts.Tag;
using BlogPost.Application.Mapper;
using BlogPost.Application.Tags.Common;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Primitives;
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
        var tags = await _tagRepository.GetAllAsync(cancellationToken);
        var mappedTags = tags.Select(t => t.ToTagResponse());

        return  Result<IEnumerable<TagResponse>>.Success(mappedTags);
    }
}