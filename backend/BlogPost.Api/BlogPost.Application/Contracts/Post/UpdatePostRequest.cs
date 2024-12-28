namespace BlogPost.Application.Contracts.Blog;

public record UpdatePostRequest(
    string Title,
    string Text,
    string ImageUrl
);