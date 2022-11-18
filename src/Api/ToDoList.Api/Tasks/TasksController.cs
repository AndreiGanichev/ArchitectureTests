using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Tasks.Application.Contracts;

namespace ToDoList.Api.Tasks;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpPost]
    public async Task<IActionResult> AddTask(
        Guid userId,
        string title,
        CancellationToken cancellationToken)
    {
        var command = new AddTaskCommand(userId, title);
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetTaskQuery(id);
        var task = await _mediator.Send(query, cancellationToken);
        return Ok(task);
    }
}