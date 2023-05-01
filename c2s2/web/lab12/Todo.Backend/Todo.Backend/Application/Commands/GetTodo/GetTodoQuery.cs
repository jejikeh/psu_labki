using MediatR;

namespace Todo.Backend.Application.Commands.GetTodo;

public class GetTodoQuery : IRequest<Models.Todo>
{
    public Guid Id { get; set; }
}