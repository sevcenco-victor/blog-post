using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Users.Commands.UpdateUser;

public record UpdateUserRequest(Guid Id, string Username, string Email);