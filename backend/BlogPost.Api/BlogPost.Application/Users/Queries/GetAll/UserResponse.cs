namespace BlogPost.Application.Contracts.User;

public sealed record UserResponse(int Id, string Username, string Email, DateOnly Birthday);