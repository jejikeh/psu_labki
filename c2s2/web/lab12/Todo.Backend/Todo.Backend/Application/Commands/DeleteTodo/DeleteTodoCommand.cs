using MediatR;

namespace Todo.Backend.Application.Commands.DeleteTodo;

public class DeleteTodoCommand : IRequest
{
    public Guid Id { get; set; }
}