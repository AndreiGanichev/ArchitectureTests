using MediatR;
using ToDoList.Tasks.Application.Contracts;
using ToDoList.Tasks.Application.Contracts.GetTask;
using ToDoList.Tasks.Application.Internals.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ToDoList.Tasks.Application.Internals;

internal sealed class GetTaskHandler : IRequestHandler<GetTaskQuery, TaskDto?>
{
    private readonly ITaskRepository _tasks;

    public GetTaskHandler(ITaskRepository tasks)
    {
        _tasks = tasks;
    }

    public Task<TaskDto?> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        var task = _tasks.Get(request.TaskId);

        var result = task is not null
            ? new TaskDto(task.Id, task.AuthorId, task.Title.ToString(), task.Date, task.RemindAt)
            : null;

        return Task.FromResult(result);
    }
}