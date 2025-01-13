namespace BlogPost.Application.Contracts.User;

public record CreateUserRequest(string Username, string Email, string Password);