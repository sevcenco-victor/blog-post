using BlogPost.Domain.Primitives;
using BlogPost.Domain.Users;
using MediatR;

namespace BlogPost.Application.Users.Queries.EmailUniqueChecker;

public class EmailUniqueCheckerHandler : IRequestHandler<EmailUniqueCheckerQuery, Result<bool>>
{
    private readonly IUserRepository _userRepository;

    public EmailUniqueCheckerHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<bool>> Handle(EmailUniqueCheckerQuery request, CancellationToken cancellationToken)
    {
        var isEmailUnique = await _userRepository.IsEmailUnique(request.Email);
        return Result<bool>.Success(isEmailUnique);
    }
}