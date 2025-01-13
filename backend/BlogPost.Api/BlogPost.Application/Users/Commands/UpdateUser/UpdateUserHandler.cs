using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Primitives;
using BlogPost.Domain.Users;
using MediatR;

namespace BlogPost.Application.Users.Commands.UpdateUser;

public class UpdateUserHandler : IRequestHandler<UpdateUserCommand, Result<bool>>
{
    private readonly IUserRepository _userRepository;

    public UpdateUserHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<Result<bool>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var mappedUser = request.Data.ToEntity();
        var result = await _userRepository.UpdateAsync(mappedUser, cancellationToken);

        return result
            ? Result<bool>.Success(true)
            : Result<bool>.Failure(UserErrors.NotFoundById(request.Data.Id));
    }
}