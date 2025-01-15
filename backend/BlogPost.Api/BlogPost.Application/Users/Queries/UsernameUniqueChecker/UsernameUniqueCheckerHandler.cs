using BlogPost.Domain.Primitives;
using BlogPost.Domain.Users;
using MediatR;

namespace BlogPost.Application.Users.Queries.UsernameUniqueChecker;

public class UsernameUniqueCheckerHandler : IRequestHandler<UsernameUniqueCheckerQuery, Result<bool>>
{
    private readonly IUserRepository _userRepository;

    public UsernameUniqueCheckerHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<bool>> Handle(UsernameUniqueCheckerQuery request, CancellationToken cancellationToken)
    {
        var result = await _userRepository.IsUsernameUnique(request.Username);
        return Result<bool>.Success(result);
    }
}