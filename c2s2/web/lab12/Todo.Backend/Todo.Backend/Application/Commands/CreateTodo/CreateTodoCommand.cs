using MediatR;

namespace Todo.Backend.Application.Commands.CreateTodo;

public class CreateTodoCommand : IRequest<Models.Todo>
{
    public string Title { get; set; } = string.Empty;
}