using ToDoList.BuildingBlocks;

namespace ToDoList.Tasks.Domain;

public class Task : Entity, IAggregateRoot
{
    public Guid Id { get; }
    public Title Title { get; private set; }
    public Notification Notification { get; private set; }
    
    public DateTime UtcTime { get; private set; }
    public DateTime ModifiedUtcTime { get; private set; }
}