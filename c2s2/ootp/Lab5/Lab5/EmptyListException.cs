namespace Lab5;

public class EmptyListException : Exception
{
    public EmptyListException(string message)
        : base(message)
    {
    }

    public EmptyListException(string message, Exception inner)
        : base(message, inner)
    {
    }
}