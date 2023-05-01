using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Backend.Application.Commands.CreateTodo;
using Todo.Backend.Application.Commands.DeleteTodo;
using Todo.Backend.Application.Commands.GetTodo;
using Todo.Backend.Application.Commands.GetTodos;
using Todo.Backend.Application.Commands.UpdateTodo;

namespace Todo.Backend.Controllers;

[Route("api/[controller]/")]
[ApiController]
public class TodoController : ControllerBase
{
    private IMediator? _mediator;
    private IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Models.Todo>>> GetAllTodos()
    {
        if (Mediator is null)
            return BadRequest("Internal server error");

        var todo = await Mediator.Send(new GetTodosQuery());
        return Ok(todo);
    }
    
    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Models.Todo>> GetTodoDetails(Guid id)
    {
        if (Mediator is null)
            return BadRequest("Internal server error");

        var todo = await Mediator.Send(new GetTodoQuery()
        {
            Id = id
        });
        
        return Ok(todo);
    }
    
    [HttpPost]
    public async Task<ActionResult<Models.Todo>> CreateTodo([FromBody] CreateTodoCommand createTodoCommand)
    {
        if (Mediator is null)
            return BadRequest("Internal server error");

        var author = await Mediator.Send(createTodoCommand);
        return Ok(author);
    }
    
    [HttpPut]
    public async Task<ActionResult<Models.Todo>> UpdateTodo(Guid id, [FromBody] UpdateTodoCommand updateTodoCommand)
    {
        if (Mediator is null)
            return BadRequest("Internal server error");

        var updatedTodo = await Mediator.Send(updateTodoCommand);
        return Ok(updatedTodo);
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<ActionResult> DeleteAuthor(Guid id)
    {
        if (Mediator is null)
            return BadRequest("Internal server error");

        var deleteTodoCommand = new DeleteTodoCommand()
        {
            Id = id
        };
        
        await Mediator.Send(deleteTodoCommand);

        return Ok();
    }
}