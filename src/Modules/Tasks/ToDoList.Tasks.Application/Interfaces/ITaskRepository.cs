namespace ToDoList.Tasks.Application.Internals.Interfaces;

public interface ITaskRepository
{
    public Domain.Task? Get(Guid id);
    public void Add(Domain.Task task);
}