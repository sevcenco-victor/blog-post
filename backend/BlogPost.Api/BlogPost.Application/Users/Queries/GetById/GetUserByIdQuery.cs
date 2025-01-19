using BlogPost.Domain.Primitives;
using BlogPost.Domain.Users;
using MediatR;

namespace BlogPost.Application.Users.Queries.GetById;

public sealed record GetUserByIdQuery(Guid UserId) : IRequest<Result<User>>;