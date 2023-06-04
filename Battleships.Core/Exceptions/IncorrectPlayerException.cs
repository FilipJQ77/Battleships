namespace Battleships.Core.Exceptions;

public class IncorrectPlayerException : Exception
{
    public IncorrectPlayerException() { }

    public IncorrectPlayerException(string message)
        : base(message) { }

    public IncorrectPlayerException(string message, Exception inner)
        : base(message, inner) { }
}