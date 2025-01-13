using BlogPost.Domain.Primitives;
using BlogPost.Domain.Users;
using MediatR;

namespace BlogPost.Application.Users.Queries.GetById;

public sealed record GetUserByIdQuery(int UserId) : IRequest<Result<User>>;