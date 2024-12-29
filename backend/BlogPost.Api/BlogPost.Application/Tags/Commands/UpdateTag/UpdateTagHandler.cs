using BlogPost.Application.Exceptions;
using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Tags.Commands.UpdateTag;

public class UpdateTagHandler : IRequestHandler<UpdateTagCommand, Result<bool>>
{
    private readonly ITagRepository _tagRepository;

    public UpdateTagHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Result<bool>> Handle(UpdateTagCommand request, CancellationToken cancellationToken)
    {
        var existingTag = await _tagRepository.GetByIdAsync(request.EntityId);
        if (existingTag == null)
        {
            return new Result<bool>(
                new TagNotFoundException($"Tag with id {request.EntityId} not found"));
        }

        if (!await _tagRepository.IsNameUniqueAsync(request.Entity.Name, existingTag.Id))
        {
            return new Result<bool>(
                new TagAlreadyExistsException($"Tag with name {request.Entity.Name} already exists."));
        }

        existingTag.Name = request.Entity.Name;
        existingTag.Color = request.Entity.Color;

        await _tagRepository.UpdateAsync(existingTag);

        return new Result<bool>(true);
    }
}