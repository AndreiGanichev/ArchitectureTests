using MediatR;
using ToDoList.Tasks.Application.Contracts;
using ToDoList.Tasks.Application.Internals.Interfaces;
using ToDoList.Tasks.Domain;

namespace ToDoList.Tasks.Application.Internals;

internal sealed class AddTaskHandler : IRequestHandler<AddTaskCommand>
{
    private readonly ITaskRepository _tasks;

    public AddTaskHandler(ITaskRepository tasks)
    {
        _tasks = tasks;
    }

    public Task<Unit> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        var task = Domain.Task.Create(Title.Create(request.Title));

        _tasks.Add(task);

        return Unit.Task;
    }
}