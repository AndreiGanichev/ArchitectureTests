using MediatR;
using ToDoList.Tasks.Application.Contracts;
using ToDoList.Tasks.Application.Internals.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ToDoList.Tasks.Application.Internals;

internal sealed class GetTaskHandler : IRequestHandler<GetTaskQuery, Domain.Task>
{
    private readonly ITaskRepository _tasks;

    public GetTaskHandler(ITaskRepository tasks)
    {
        _tasks = tasks;
    }

    public Task<Domain.Task> Handle(GetTaskQuery request, CancellationToken cancellationToken)
    {
        var task = _tasks.Get(request.TaskId);

        return Task.FromResult(task);
    }
}