using BlogPost.Domain.Primitives;
using BlogPost.Domain.Tags;
using MediatR;

namespace BlogPost.Application.Tags.Commands.UpdateTag;

public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, Result>
{
    private readonly ITagRepository _tagRepository;

    public UpdateTagHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Result> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var id = request.EntityId;
        var (name, color) = request.Entity;

        var existingTag = await _tagRepository.GetByIdAsync(id, cancellationToken);
        if (existingTag == null)
        {
            return Result.Failure(TagErrors.NotFoundById(id));
        }

        if (!await _tagRepository.IsNameUniqueAsync(name, existingTag.Id, cancellationToken))
        {
            return Result.Failure(TagErrors.NameAlreadyExists(name));
        }

        existingTag.Name = name;
        existingTag.Color = color;

        await _tagRepository.UpdateAsync(existingTag, cancellationToken);

        return Result.Success();
    }
}