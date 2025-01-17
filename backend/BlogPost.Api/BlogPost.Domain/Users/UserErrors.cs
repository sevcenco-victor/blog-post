using BlogPost.Domain.Abstractions;

namespace BlogPost.Domain.Users;

public static class UserErrors
{
    public static Error EmailAlreadyInUse() =>
        Error.Conflict("User.EmailAlreadyExists", "Another user is already using  this email.");

    public static Error UsernameAlreadyInUse() =>
        Error.Conflict("User.UsernameAlreadyInUse", "Another user is already using this username.");

    public static Error NotFoundByEmail(string email) =>
        Error.NotFound("User.EmailNotFound", $"No user found with email: {email}");

    public static Error NotFoundById(Guid userId) => Error.NotFound("User.NotFoundById", $"No user found with id: {userId}");
}