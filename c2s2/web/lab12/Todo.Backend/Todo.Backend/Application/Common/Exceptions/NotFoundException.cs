namespace Todo.Backend.Application.Common.Exceptions;

public class NotFoundException<T> : Exception
{
    public NotFoundException(object key) : base($"Entity {typeof(T).FullName}, ({key}) not found")
    {
    }
}