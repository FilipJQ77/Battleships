namespace Battleships.Core.Exceptions;

public class ShipValidationException : Exception
{
    public ShipValidationException()
    {
    }

    public ShipValidationException(string? message) : base(message)
    {
    }

    public ShipValidationException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}