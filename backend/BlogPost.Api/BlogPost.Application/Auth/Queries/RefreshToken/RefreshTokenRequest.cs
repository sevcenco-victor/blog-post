namespace BlogPost.Application.Contracts.Auth;

public record RefreshTokenRequest(int UserId, string RefreshToken);
