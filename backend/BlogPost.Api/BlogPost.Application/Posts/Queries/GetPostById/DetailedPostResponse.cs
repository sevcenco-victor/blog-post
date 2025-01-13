namespace BlogPost.Application.Contracts.Post;

public record DetailedPostResponse(
    int Id,
    string Title,
    string Text,
    DateOnly PostDate,
    DateTime LastEdit,
    string ImageUrl,
    string MarkDownFileLink,
    IEnumerable<Domain.Tags.Tag> Tags
);