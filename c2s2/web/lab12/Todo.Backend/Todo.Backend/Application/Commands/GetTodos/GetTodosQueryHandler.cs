using MediatR;
using Todo.Backend.Application.Interfaces;

namespace Todo.Backend.Application.Commands.GetTodos;

public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, IEnumerable<Models.Todo>>
{
    private readonly ITodoRepository _todoRepository;

    public GetTodosQueryHandler(ITodoRepository todoRepository)
    {
        _todoRepository = todoRepository;
    }

    public async Task<IEnumerable<Models.Todo>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
    {
        var todos = await _todoRepository.GetAllTodos();
        return todos;
    }
}