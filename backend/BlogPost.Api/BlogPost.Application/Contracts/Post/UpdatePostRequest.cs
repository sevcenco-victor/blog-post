namespace BlogPost.Application.Contracts.Post;

public record UpdatePostRequest(
    string Title,
    string Text,
    string ImageUrl
);