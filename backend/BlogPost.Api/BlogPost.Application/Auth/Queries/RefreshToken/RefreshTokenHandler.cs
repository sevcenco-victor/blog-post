using BlogPost.Application.Abstractions;
using BlogPost.Application.Users.Queries.GetById;
using BlogPost.Domain.Common;
using BlogPost.Domain.Primitives;
using MediatR;

namespace BlogPost.Application.Auth.Queries.RefreshToken;

public class RefreshTokenHandler : IRequestHandler<RefreshTokenQuery, Result<string>>
{
    private readonly IJwtTokenService _jwtTokenService;
    private readonly IMediator _mediator;

    public RefreshTokenHandler(IJwtTokenService jwtTokenService, IMediator mediator)
    {
        _jwtTokenService = jwtTokenService;
        _mediator = mediator;
    }

    public async Task<Result<string>> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
    {
        var (userId, refreshToken) = request.Data;
        if (string.IsNullOrEmpty(refreshToken))
        {
            return Result<string>.Failure(AuthErrors.UnAuthorized());
        }

        var result = await _mediator.Send(new GetUserByIdQuery(userId), cancellationToken);
        var user = result.Value;

        if (user.RefreshToken != refreshToken
            || user.RefreshTokenExpiry <= DateTime.UtcNow)
        {
            return Result<string>.Failure(AuthErrors.UnAuthorized());
        }

        var newToken = _jwtTokenService.GenerateToken(user);
        return Result<string>.Success(newToken);
    }
}