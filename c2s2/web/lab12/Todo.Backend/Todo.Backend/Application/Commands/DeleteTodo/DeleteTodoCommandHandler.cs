using MediatR;
using Todo.Backend.Application.Common.Exceptions;
using Todo.Backend.Application.Interfaces;

namespace Todo.Backend.Application.Commands.DeleteTodo;

public class DeleteTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
{
    private readonly ITodoRepository _todoRepository;

    public DeleteTodoCommandHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetTodo(request.Id);
        
        if (todo is null)
            throw new NotFoundException<Models.Todo>(nameof(request.Id));

        await _todoRepository.DeleteTodo(request.Id);
        await _todoRepository.SaveChangesAsync();
    }
}