using BlogPost.Application.Contracts.User;
using BlogPost.Application.Users.Commands.UpdateUser;
using BlogPost.Application.Users.Queries.Common;
using BlogPost.Domain.Users;

namespace BlogPost.Application.Mapper;

public static class UserMapperExtension
{
    public static User ToEntity(this CreateUserRequest request, string hashedPassword)
    {
        return new User
        {
            Email = request.Email,
            PasswordHash = hashedPassword,
            Username = request.Username,
        };
    }

    public static User ToEntity(this UpdateUserRequest request)
    {
        return new User
        {
            Id = request.Id,
            Email = request.Email,
            Username = request.Username,
        };
    }

    public static UserResponse ToUserResponse(this User request)
    {
        return new UserResponse(
            request.Id,
            request.Username,
            request.Email,
            request.BirthDate
        );
    }
}