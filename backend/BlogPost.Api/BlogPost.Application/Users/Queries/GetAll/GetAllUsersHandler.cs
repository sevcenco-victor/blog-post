using BlogPost.Application.Mapper;
using BlogPost.Application.Users.Queries.Common;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Users.Queries.GetAll;

public class GetAllUsersHandler : IRequestHandler<GetAllUsersQuery, Result<IEnumerable<UserResponse>>>
{
    private readonly IUserRepository _userRepository;

    public GetAllUsersHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<IEnumerable<UserResponse>>> Handle(GetAllUsersQuery request,
        CancellationToken cancellationToken)
    {
        var users = await _userRepository.GetAllAsync(cancellationToken);
        var mappedUsers = users.Select(u => u.ToUserResponse());

        return Result<IEnumerable<UserResponse>>.Success(mappedUsers);
    }
}