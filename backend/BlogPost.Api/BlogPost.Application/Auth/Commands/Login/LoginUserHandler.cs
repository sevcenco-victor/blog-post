using BlogPost.Application.Abstractions;
using BlogPost.Application.Auth.Common;
using BlogPost.Application.Users.Queries.GetByEmail;
using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Common;
using BlogPost.Domain.Primitives;
using BlogPost.Domain.Users;
using MediatR;

namespace BlogPost.Application.Auth.Commands.Login;

public class LoginUserHandler : IRequestHandler<LoginUserCommand, Result<TokenResponse>>
{
    private readonly IUserRepository _userRepository;
    private readonly IPasswordHasher _passwordHasher;
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IMediator _mediator;

    public LoginUserHandler(IUserRepository userRepository, IPasswordHasher passwordHasher,
        IJwtTokenService jwtTokenService, IMediator mediator)
    {
        _userRepository = userRepository;
        _passwordHasher = passwordHasher;
        _jwtTokenService = jwtTokenService;
        _mediator = mediator;
    }

    public async Task<Result<TokenResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var (email, password) = request.Data;

        var result = await _mediator.Send(new GetByEmailQuery(email), cancellationToken);
        if (result.IsFailure)
        {
            return Result<TokenResponse>.Failure(AuthErrors.InvalidCredentials());
        }

        var user = result.Value;

        var validPassword = _passwordHasher.VerifyHashedPassword(user.PasswordHash, password);

        if (!validPassword)
        {
            return Result<TokenResponse>.Failure(AuthErrors.InvalidCredentials());
        }

        var tokenResponse = new TokenResponse(
            _jwtTokenService.GenerateToken(user),
            _jwtTokenService.GenerateRefreshToken()
        );

        user.RefreshToken = tokenResponse.RefreshToken;
        user.RefreshTokenExpiry = DateTime.UtcNow.AddDays(7);

        var isUpdated = await _userRepository.UpdateAsync(user, cancellationToken);

        return !isUpdated
            ? Result<TokenResponse>.Failure(Error.Failure("Login.GenerateToken", "An error occured"))
            : Result<TokenResponse>.Success(tokenResponse);
    }
}