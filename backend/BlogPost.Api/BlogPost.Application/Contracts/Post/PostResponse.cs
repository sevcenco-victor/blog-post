
namespace BlogPost.Contracts.Post;

public record PostResponse(
    int Id,
    string Title,
    string Text,
    DateOnly PostDate,
    DateTime LastEdit,
    string ImageUrl,
    IEnumerable<Domain.Entities.Tag> Tags
);