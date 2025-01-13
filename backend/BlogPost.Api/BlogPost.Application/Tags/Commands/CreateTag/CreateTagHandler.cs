using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Exceptions;
using BlogPost.Domain.Primitives;
using BlogPost.Domain.Tags;
using Microsoft.Extensions.Logging;
using MediatR;

namespace BlogPost.Application.Tags.Commands.CreateTag;

public sealed class CreateTagHandler : IRequestHandler<CreateTagCommand, Result<int>>
{
    private readonly ITagRepository _tagRepository;
    private readonly ILogger<CreateTagHandler> _logger;

    public CreateTagHandler(ITagRepository tagRepository, ILogger<CreateTagHandler> logger)
    {
        _tagRepository = tagRepository;
        _logger = logger;
    }

    public async Task<Result<int>> Handle(CreateTagCommand request, CancellationToken cancellationToken)
    {
        var (name, color) = request.Entity;

        var existingTag = await _tagRepository.GetByNameAsync(name, cancellationToken);

        if (existingTag != null)
        {
            _logger.LogWarning("Tag with Name: {Name} already exists.", name);
            return Result<int>.Failure(TagErrors.NameAlreadyExists(name));
        }

        var tag = new Tag { Name = name, Color = color };
        _logger.LogDebug("Creating tag to database...");
        var entityId = await _tagRepository.CreateAsync(tag, cancellationToken);

        _logger.LogInformation("Tag with Id: {Id} added successfully to database", entityId);

        return Result<int>.Success(entityId);
    }
}