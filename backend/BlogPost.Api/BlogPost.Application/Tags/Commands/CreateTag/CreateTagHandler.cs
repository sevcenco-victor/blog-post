using BlogPost.Application.Exceptions;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Entities;
using LanguageExt.Common;
using MediatR;

namespace BlogPost.Application.Tags.Commands.CreateTag;

public class CreateTagHandler : IRequestHandler<CreateTagCommand, Result<int>>
{
    private readonly ITagRepository _tagRepository;

    public CreateTagHandler(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<Result<int>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var entity = request.Entity;

        var existingTag = await _tagRepository.GetByNameAsync(entity.Name);

        if (existingTag != null)
        {
            var error = new TagAlreadyExistsException($"Tag with name {entity.Name} already exists.");
            return new Result<int>(error);
        }

        var tag = new Tag() { Name = entity.Name, Color = entity.Color };
        var entityId = await _tagRepository.CreateAsync(tag);

        return new Result<int>(entityId);
    }
}