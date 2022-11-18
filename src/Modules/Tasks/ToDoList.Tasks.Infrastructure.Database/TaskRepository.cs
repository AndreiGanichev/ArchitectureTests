using ToDoList.Tasks.Application.Internals.Interfaces;
using Task = ToDoList.Tasks.Domain.Task;

namespace ToDoList.Tasks.Infrastructure.Database;

public class TaskRepository : ITaskRepository
{
    public Task Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public void Add(Task task)
    {
        throw new NotImplementedException();
    }
}