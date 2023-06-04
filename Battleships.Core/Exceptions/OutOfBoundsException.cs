namespace Battleships.Core.Exceptions;

public class OutOfBoundsException : Exception
{
    public OutOfBoundsException()
    {
    }

    public OutOfBoundsException(string? message) : base(message)
    {
    }

    public OutOfBoundsException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}