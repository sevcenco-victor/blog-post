using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Users.Queries.UsernameUniqueChecker;

public sealed record UsernameUniqueCheckerQuery(string Username) : IRequest<Result<bool>>;