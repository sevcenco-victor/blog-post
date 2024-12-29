using BlogPost.Application.Exceptions;
using BlogPost.Domain.Abstractions;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Tags.Commands.DeleteTag;

public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, Result<bool>>
{
    private readonly ITagRepository _tagRepository;

    public DeleteTagHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Result<bool>> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _tagRepository.DeleteAsync(request.Id);
        if (!deleted)
        {
            var error = new TagNotFoundException($"Tag with id {request.Id} not found");
            return new Result<bool>(error);
        }

        return new Result<bool>(true);
    }
}