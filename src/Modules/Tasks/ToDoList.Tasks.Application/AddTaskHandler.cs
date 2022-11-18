using MediatR;
using ToDoList.Tasks.Application.Contracts.AddTask;
using ToDoList.Tasks.Application.Internals.Interfaces;
using ToDoList.Tasks.Domain;
using Task = System.Threading.Tasks.Task;

namespace ToDoList.Tasks.Application.Internals;

internal sealed class AddTaskHandler : IRequestHandler<AddTaskCommand, Guid>
{
    private readonly ITaskRepository _tasks;

    public AddTaskHandler(ITaskRepository tasks)
    {
        _tasks = tasks;
    }

    public Task<Guid> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        var task = Domain.Task.Create(request.UserId, Title.Create(request.Title), request.Date, request.RemindAt);

        _tasks.Add(task);

        return Task.FromResult(task.Id);
    }
}