using BlogPost.Application.Contracts.Tag;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Exceptions;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Tags.Queries.GetTagByName;

public class GetTagByNameHandler : IRequestHandler<GetTagByNameQuery, Result<TagResponse>>
{
    private readonly ITagRepository _tagRepository;

    public GetTagByNameHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Result<TagResponse>> Handle(GetTagByNameQuery request, CancellationToken cancellationToken)
    {
        var tagName = request.Name;

        var tag = await _tagRepository.GetByNameAsync(tagName);
        if (tag == null)
        {
            return Result<TagResponse>.Failure(TagErrors.NotFoundByName(tagName));
        }

        return Result<TagResponse>.Success(tag.ToTagResponse());
    }
}