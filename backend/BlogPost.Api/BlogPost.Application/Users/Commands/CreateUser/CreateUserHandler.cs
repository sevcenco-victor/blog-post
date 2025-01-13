using BlogPost.Application.Mapper;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Users.Commands.CreateUser;

public class CreateUserHandler(IUserRepository userRepository) : IRequestHandler<CreateUserCommand, Result<int>>
{

    public async Task<Result<int>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        // var mappedUser = request.Request.ToEntity();
        // var userId = await userRepository.CreateAsync(mappedUser, cancellationToken);
        
        return Result<int>.Success(-22);
    }
}