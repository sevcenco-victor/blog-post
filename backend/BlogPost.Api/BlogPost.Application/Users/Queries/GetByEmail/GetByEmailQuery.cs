using BlogPost.Application.Contracts.User;
using BlogPost.Domain.Primitives;
using BlogPost.Domain.Users;
using MediatR;

namespace BlogPost.Application.Users.Queries.GetByEmail;

public sealed record GetByEmailQuery(string Email) : IRequest<Result<User>>;