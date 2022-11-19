using MediatR;
using ToDoList.Tasks.Application.Internals.Interfaces;

namespace ToDoList.Tasks.Infrastructure.Database;

public class TaskRepository : ITaskRepository
{
    private readonly IMediator _mediator;
    
    private readonly Dictionary<Guid,Domain.Task> _tasks = new();

    public TaskRepository(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Domain.Task? Get(Guid id) => _tasks.TryGetValue(id, out var value) ? value : null;

    public async Task Add(Domain.Task task)
    {
        _tasks.Add(task.Id, task);
        
        foreach (var @event in task.DomainEvents)
        {
            await _mediator.Publish(@event);
        }
    }
}