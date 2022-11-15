using MediatR;
using Microsoft.AspNetCore.Authorization;
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


    [Authorize]
    [HttpPost]
    public async Task<IActionResult> AddTask(CancellationToken cancellationToken)
    {
        var command = new AddTaskCommand("a task");
        await _mediator.Send(command, cancellationToken);
        return Ok();
    }
}