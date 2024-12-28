namespace BlogPost.Application.Exceptions;

public class PostNotFoundException : Exception
{
    public PostNotFoundException(string message) : base(message)
    {
    }

    public PostNotFoundException(string message, Exception innerException) : base(message, innerException)
    {
    }
}