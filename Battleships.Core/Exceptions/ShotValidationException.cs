namespace Battleships.Core.Exceptions;

public class ShotValidationException : Exception
{
    public ShotValidationException()
    {
    }

    public ShotValidationException(string? message) : base(message)
    {
    }

    public ShotValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}