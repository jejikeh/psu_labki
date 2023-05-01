using MediatR;
using Todo.Backend.Application.Common.Exceptions;
using Todo.Backend.Application.Interfaces;

namespace Todo.Backend.Application.Commands.GetTodo;

public class GetTodoQueryHandler : IRequestHandler<GetTodoQuery, Models.Todo>
{
    private readonly ITodoRepository _todoRepository;

    public GetTodoQueryHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<Models.Todo> Handle(GetTodoQuery request, CancellationToken cancellationToken)
    {
        var todo = await _todoRepository.GetTodo(request.Id);

        if (todo is null)
            throw new NotFoundException<Models.Todo>(nameof(request.Id));

        return todo;
    }
}