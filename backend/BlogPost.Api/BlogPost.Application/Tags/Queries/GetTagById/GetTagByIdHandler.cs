using BlogPost.Application.Contracts.Tag;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Exceptions;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Tags.Queries.GetTagById;

public class GetTagByIdHandler : IRequestHandler<GetTagByIdQuery, Result<TagResponse>>
{
    private readonly ITagRepository _tagRepository;

    public GetTagByIdHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Result<TagResponse>> Handle(GetTagByIdQuery request, CancellationToken cancellationToken)
    {
        var tagId = request.Id;

        var tag = await _tagRepository.GetByIdAsync(tagId);
        if (tag == null)
        {
            return Result<TagResponse>.Failure(TagErrors.NotFoundById(tagId));
        }

        return Result<TagResponse>.Success(tag.ToTagResponse());
    }
}