using BlogPost.Application.Users.Queries.Common;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Users.Queries.GetAll;

public sealed record GetAllUsersQuery : IRequest<Result<IEnumerable<UserResponse>>>;
