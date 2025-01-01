using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Exceptions;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Tags.Commands.DeleteTag;

public class DeleteTagHandler : IRequestHandler<DeleteTagCommand, Result>
{
    private readonly ITagRepository _tagRepository;

    public DeleteTagHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Result> Handle(DeleteTagCommand request, CancellationToken cancellationToken)
    {
        var deleted = await _tagRepository.DeleteAsync(request.Id);
        if (!deleted)
        {
            return Result.Failure(TagErrors.NotFoundById(request.Id));
        }

        return Result.Success();
    }
}