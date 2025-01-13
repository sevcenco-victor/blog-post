using BlogPost.Domain.Abstractions;

namespace BlogPost.Domain.Common;

public static class AuthErrors
{
    public static Error InvalidCredentials() =>
        Error.Validation("Auth.InvalidCredentials", "Invalid email or password");

    public static Error UnAuthorized() => Error.UnAuthorized("Auth.UnAuthorized", "UnAuthorized");
}