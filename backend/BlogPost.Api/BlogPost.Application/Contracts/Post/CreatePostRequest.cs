namespace BlogPost.Application.Contracts.Post;

public record CreatePostRequest(
    string Title,
    string Text,
    string ImageUrl,
    IEnumerable<int> TagIds
);