using MediatR;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Tasks.Application.Contracts.AddTask;
using ToDoList.Tasks.Application.Contracts.GetTask;

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
        [FromBody] AddTaskRequest request,
        CancellationToken cancellationToken)
    {
        var command = new AddTaskCommand(request.UserId, request.Title, DateOnly.FromDateTime(request.Date), request.RemindAt);
        var taskId = await _mediator.Send(command, cancellationToken);
        return Ok(taskId);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> GetTask(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetTaskQuery(id);
        var task = await _mediator.Send(query, cancellationToken);
        return Ok(task);
    }
}