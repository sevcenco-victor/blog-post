
namespace BlogPost.Application.Contracts.Post;

public record PostResponse(
    int Id,
    string Title,
    string Text,
    DateOnly PostDate,
    string ImageUrl,
    IEnumerable<Domain.Tags.Tag> Tags
);