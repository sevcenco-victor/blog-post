using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Users.Queries.EmailUniqueChecker;

public record EmailUniqueCheckerQuery(string Email) : IRequest<Result<bool>>;