using MediatR;

namespace Todo.Backend.Application.Commands.GetTodos;

public class GetTodosQuery : IRequest<IEnumerable<Models.Todo>>
{
    
}