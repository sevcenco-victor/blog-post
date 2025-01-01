using BlogPost.Domain.Abstractions;

namespace BlogPost.Domain.Primitives;

public class Result<TValue>
{
    private Result(TValue value, bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new ArgumentException("Successful result cannot have an error.", nameof(error));
        }

        if (!isSuccess && error == Error.None)
        {
            throw new ArgumentException("Failure result must have an error.", nameof(error));
        }

        Value = value;
        IsSuccess = isSuccess;
        Error = error;
    }

    public TValue Value { get; }
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static Result<TValue> Success(TValue value) => new(value, true, Error.None);
    public static Result<TValue> Failure(Error error) => new(default, false, error);

    public void Match(Action<TValue> onSuccess, Action<Error> onFailure)
    {
        if (IsSuccess) onSuccess(Value);
        else onFailure(Error);
    }

    public TReturn Match<TReturn>(Func<TValue, TReturn> onSuccess, Func<Error, TReturn> onFailure)
    {
        return IsSuccess ? onSuccess(Value) : onFailure(Error);
    }
}

public class Result
{
    private Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None)
        {
            throw new ArgumentException("Successful result cannot have an error.", nameof(error));
        }

        if (!isSuccess && error == Error.None)
        {
            throw new ArgumentException("Failure result must have an error.", nameof(error));
        }

        IsSuccess = isSuccess;
        Error = error;
    }

    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    public static Result Success() => new(true, Error.None);
    public static Result Failure(Error error) => new(false, error);

    public void Match(Action onSuccess, Action<Error> onFailure)
    {
        if (IsSuccess) onSuccess();
        else onFailure(Error);
    }

    public TReturn Match<TReturn>(Func<TReturn> onSuccess, Func<Error, TReturn> onFailure)
    {
        return IsSuccess ? onSuccess() : onFailure(Error);
    }
}