using MediatR;
using Todo.Backend.Application.Interfaces;

namespace Todo.Backend.Application.Commands.CreateTodo;

public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Models.Todo>
{
    private readonly ITodoRepository _todoRepository;

    public CreateTodoCommandHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Models.Todo> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = new Models.Todo
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            StartDate = DateOnly.FromDateTime(DateTime.Today),
            EndDate = DateOnly.MinValue,
            IsDone = false
        };

        await _todoRepository.CreateTodo(todo);
        await _todoRepository.SaveChangesAsync();
        return todo;
    }
}