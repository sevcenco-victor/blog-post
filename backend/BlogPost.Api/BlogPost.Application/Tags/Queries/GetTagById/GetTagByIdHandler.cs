using BlogPost.Application.Contracts.Tag;
using BlogPost.Application.Exceptions;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using LanguageExt.Common;
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
        var tag = await _tagRepository.GetByIdAsync(request.Id);
        if (tag == null)
        {
            var error = new TagNotFoundException($"Tag with id: {request.Id} was not found");
            return new Result<TagResponse>(error);
        }

        return new Result<TagResponse>(tag.ToTagResponse());
    }
}