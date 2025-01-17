using BlogPost.Application.Auth.Common;

namespace BlogPost.Application.Auth.Commands.Register;

public record RegisterUserResponse(Guid UserId, TokenResponse Tokens);