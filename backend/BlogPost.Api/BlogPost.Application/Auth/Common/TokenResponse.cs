namespace BlogPost.Application.Auth.Common;

public record TokenResponse(string AccessToken, string RefreshToken);