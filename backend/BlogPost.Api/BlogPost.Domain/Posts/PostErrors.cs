using BlogPost.Domain.Abstractions;

namespace BlogPost.Domain.Posts;

public static class PostErrors
{
    public static Error ValidationError(string message) => Error.Validation("Posts.ValidationError", message);
    public static Error NotFoundById(Guid id) => Error.NotFound("Posts.NotFound", $"Post with id {id} was not found.");
}