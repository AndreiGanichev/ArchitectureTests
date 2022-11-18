using ToDoList.Tasks.Application.Internals.Interfaces;

namespace ToDoList.Tasks.Infrastructure.Database;

public class TaskRepository : ITaskRepository
{
    private readonly Dictionary<Guid,Domain.Task> _tasks = new();

    public Domain.Task? Get(Guid id) => _tasks.TryGetValue(id, out var value) ? value : null;

    public void Add(Domain.Task task)
    {
        _tasks.Add(task.Id, task);
        
        var domainEvents = task.DomainEvents;
        //ToDo: publish domain events
    }
}