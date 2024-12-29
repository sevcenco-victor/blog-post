using BlogPost.Application.Contracts.Tag;
using BlogPost.Application.Exceptions;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using LanguageExt.Common;
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
        var tag = await _tagRepository.GetByNameAsync(request.Name);
        if (tag == null)
        {
            var error = new TagNotFoundException($"Tag with name {request.Name} does not exist");
            return new Result<TagResponse>(error);
        }

        return new Result<TagResponse>(tag.ToTagResponse());
    }
}