namespace BlogPost.Application.Exceptions;

public class TagAlreadyExistsException : Exception
{
    public TagAlreadyExistsException(string message) : base(message)
    {
    }

    public TagAlreadyExistsException(string message, Exception innerException) : base(message, innerException)
    {
    }
}