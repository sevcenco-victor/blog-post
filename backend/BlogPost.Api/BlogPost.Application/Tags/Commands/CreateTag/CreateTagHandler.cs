using BlogPost.Domain.Primitives;
using BlogPost.Domain.Tags;
using Microsoft.Extensions.Logging;
using MediatR;

namespace BlogPost.Application.Tags.Commands.CreateTag;

public sealed class CreateTagHandler : IRequestHandler<CreateTagCommand, Result<Guid>>
{
    private readonly ITagRepository _tagRepository;
    private readonly ILogger<CreateTagHandler> _logger;

    public CreateTagHandler(ITagRepository tagRepository, ILogger<CreateTagHandler> logger)
    {
        _tagRepository = tagRepository;
        _logger = logger;
    }

    public async Task<Result<Guid>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var (name, color) = request.Entity;

        var existingTag = await _tagRepository.GetByNameAsync(name, cancellationToken);

        if (existingTag != null)
        {
            _logger.LogWarning("Tag with Name: {Name} already exists.", name);
            return Result<Guid>.Failure(TagErrors.NameAlreadyExists(name));
        }

        var tag = new Tag { Name = name, Color = color };
        _logger.LogDebug("Creating tag to database...");
        var entityId = await _tagRepository.CreateAsync(tag, cancellationToken);

        _logger.LogInformation("Tag with Id: {Id} added successfully to database", entityId);

        return Result<Guid>.Success(entityId);
    }
}