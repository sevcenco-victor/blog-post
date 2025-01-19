using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Primitives;
using BlogPost.Domain.Users;
using MediatR;

namespace BlogPost.Application.Users.Queries.GetByEmail;

public class GetByEmailCommand : IRequestHandler<GetByEmailQuery, Result<User>>
{
    private readonly IUserRepository _userRepository;

    public GetByEmailCommand(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<User>> Handle(GetByEmailQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user == null)
        {
            return Result<User>.Failure(UserErrors.NotFoundByEmail(request.Email));
        }

        return Result<User>.Success(user);
    }
}