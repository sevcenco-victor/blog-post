using BlogPost.Application.Auth.Common;

namespace BlogPost.Application.Auth.Commands.Register;

public record RegisterUserResponse(int UserId, TokenResponse Tokens);