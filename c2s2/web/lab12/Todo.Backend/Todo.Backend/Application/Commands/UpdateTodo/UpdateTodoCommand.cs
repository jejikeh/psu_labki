using MediatR;

namespace Todo.Backend.Application.Commands.UpdateTodo;

public class UpdateTodoCommand : IRequest<Models.Todo>
{
    public Guid Id { get; set; }
    public string? Title { get; set; } = string.Empty;
    public bool IsDone { get; set; }
}