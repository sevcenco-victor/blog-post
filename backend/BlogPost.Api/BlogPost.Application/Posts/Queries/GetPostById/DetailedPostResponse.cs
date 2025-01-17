namespace BlogPost.Application.Posts.Queries.GetPostById;

public record DetailedPostResponse(
    Guid Id,
    string Title,
    string Text,
    DateOnly PostDate,
    DateTime LastEdit,
    string ImageUrl,
    string MarkDownFileLink,
    IEnumerable<Domain.Tags.Tag> Tags
);