namespace BlogPost.Application.Posts.Commands.CreatePost;

public record CreatePostRequest(
    string Title,
    string Text,
    string ImageUrl,
    string MarkdownFileContent,
    IEnumerable<Guid> TagIds,
    Guid UserId
);