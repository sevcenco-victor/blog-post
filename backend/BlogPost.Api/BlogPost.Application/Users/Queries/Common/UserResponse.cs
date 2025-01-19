namespace BlogPost.Application.Users.Queries.Common;

public sealed record UserResponse(Guid Id, string Username, string Email, DateOnly Birthday);