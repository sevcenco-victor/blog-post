
namespace BlogPost.Application.Posts.Common;

public record PostResponse(
    Guid Id,
    string Title,
    string Text,
    DateOnly PostDate,
    string ImageUrl,
    IEnumerable<Domain.Tags.Tag> Tags
);