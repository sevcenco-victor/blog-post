using BlogPost.Application.Abstractions;
using BlogPost.Application.Auth.Common;
using BlogPost.Application.Mapper;
using BlogPost.Application.Users.Queries.EmailUniqueChecker;
using BlogPost.Application.Users.Queries.UsernameUniqueChecker;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Primitives;
using BlogPost.Domain.Users;
using MediatR;

namespace BlogPost.Application.Auth.Commands.Register;

public sealed class RegisterUserHandler : IRequestHandler<RegisterUserCommand, Result<RegisterUserResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IMediator _mediator;

    public RegisterUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher,
        IJwtTokenService jwtTokenService, IMediator mediator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
        _mediator = mediator;
    }

    public async Task<Result<RegisterUserResponse>> Handle(RegisterUserCommand request,
        CancellationToken cancellationToken)
    {
        var (username, email, password) = request.Request;
        var isEmailUnique = await _mediator.Send(new EmailUniqueCheckerQuery(email), cancellationToken);

        if (!isEmailUnique.Value)
        {
            return Result<RegisterUserResponse>.Failure(UserErrors.EmailAlreadyInUse());
        }

        var isUsernameUnique = await _mediator.Send(new UsernameUniqueCheckerQuery(username), cancellationToken);
        if (!isUsernameUnique.Value)
        {
            return Result<RegisterUserResponse>.Failure(UserErrors.UsernameAlreadyInUse());
        }

        var hashedPassword = _passwordHasher.HashPassword(password);

        var userEntity = request.Request.ToEntity(hashedPassword);

        var tokenResponse = new TokenResponse(
            _jwtTokenService.GenerateToken(userEntity),
            _jwtTokenService.GenerateRefreshToken()
        );
        
        userEntity.Role = UserRoles.User;
        userEntity.RefreshToken = tokenResponse.RefreshToken;
        userEntity.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

        var userId = await _userRepository.CreateAsync(userEntity, cancellationToken);

        return Result<RegisterUserResponse>.Success(new RegisterUserResponse(userId, tokenResponse));
    }
}