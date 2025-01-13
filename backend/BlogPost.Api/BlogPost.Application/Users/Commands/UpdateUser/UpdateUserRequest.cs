using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Users.Commands.UpdateUser;

public record UpdateUserRequest(int Id, string Username, string Email);