namespace BlogPost.Application.Users.Queries.Common;

public sealed record UserResponse(int Id, string Username, string Email, DateOnly Birthday);