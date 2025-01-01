using Microsoft.AspNetCore.Diagnostics;

namespace BlogPost.Api;

internal sealed class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;
    private readonly IProblemDetailsService _problemDetailsService;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger, IProblemDetailsService problemDetailsService)
    {
        _logger = logger;
        _problemDetailsService = problemDetailsService;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "An Exception occured: {Message}", exception.Message);

        httpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

        return await _problemDetailsService.TryWriteAsync(new ProblemDetailsContext()
        {
            HttpContext = httpContext,
            Exception = exception,
            ProblemDetails =
            {
                Type = exception.GetType().Name,
                Title = "Internal Server Error",
                Detail = exception.Message,
                Instance = $"{httpContext.Request.Method} {httpContext.Request.Path}",
                Extensions = new Dictionary<string, object?>
                {
                    {"requestId", httpContext.TraceIdentifier}
                }
            }
        });
    }
}