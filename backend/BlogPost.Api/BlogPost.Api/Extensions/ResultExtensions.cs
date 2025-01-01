using BlogPost.Domain.Abstractions;
using BlogPost.Domain.Primitives;
using Microsoft.AspNetCore.Mvc;

namespace BlogPost.Api.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToProblemDetails(this Result result)
    {
        if (result.IsSuccess)
        {
            throw new InvalidOperationException("Can't convert success result to problem");
        }

        return ConvertToProblemDetails(result.Error);
    }

    public static IActionResult ToProblemDetails<TValue>(this Result<TValue> result)
    {
        return ConvertToProblemDetails(result.Error);
    }

    private static ObjectResult ConvertToProblemDetails(Error error)
    {
        return new ObjectResult(new ProblemDetails
        {
            Status = GetStatusCode(error.Type),
            Title = GetTitle(error.Type),
            Type = GetType(error.Type),
            Extensions = new Dictionary<string, object?>
            {
                { "errors", new[] { error } }
            }
        });

        static int GetStatusCode(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => StatusCodes.Status400BadRequest,
                ErrorType.NotFound => StatusCodes.Status404NotFound,
                ErrorType.Conflict => StatusCodes.Status409Conflict,
                _ => StatusCodes.Status500InternalServerError,
            };

        static string GetTitle(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => "Bad Request",
                ErrorType.NotFound => "Not Found",
                ErrorType.Conflict => "Conflict",
                _ => "Internal Server Error",
            };

        static string GetType(ErrorType errorType) =>
            errorType switch
            {
                ErrorType.Validation => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.1",
                ErrorType.NotFound => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.4",
                ErrorType.Conflict => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.5.8",
                _ => "https://datatracker.ietf.org/doc/html/rfc7231#section-6.6.1",
            };
    }
}