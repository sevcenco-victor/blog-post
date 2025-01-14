using BlogPost.Domain.Entities;
using BlogPost.Domain.Users;

namespace BlogPost.Application.Abstractions;

public interface IJwtTokenService
{
    string GenerateToken(User user);
    string GenerateRefreshToken();
}