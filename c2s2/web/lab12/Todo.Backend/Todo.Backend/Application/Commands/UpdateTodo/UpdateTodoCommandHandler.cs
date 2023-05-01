using MediatR;
using Todo.Backend.Application.Common.Exceptions;
using Todo.Backend.Application.Interfaces;

namespace Todo.Backend.Application.Commands.UpdateTodo;

public class UpdateTodoCommandHandler : IRequestHandler<UpdateTodoCommand, Models.Todo>
{
    private readonly ITodoRepository _todoRepository;

    public UpdateTodoCommandHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Models.Todo> Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetTodo(request.Id);

        if (todo is null)
            throw new NotFoundException<Models.Todo>(nameof(request.Id));
        
        
        var updateTodo = new Models.Todo
        {
            Id = request.Id,
            Title = request.Title == string.Empty || request.Title is null ? todo.Title : request.Title,
            StartDate = default,
            EndDate = request.IsDone ? DateOnly.FromDateTime(DateTime.Today) : todo.EndDate,
            IsDone = request.IsDone
        };

        await _todoRepository.UpdateTodo(updateTodo);
        await _todoRepository.SaveChangesAsync();
        return updateTodo;
    }
}