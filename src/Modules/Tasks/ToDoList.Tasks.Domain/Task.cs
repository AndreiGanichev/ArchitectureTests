using ToDoList.BuildingBlocks;

namespace ToDoList.Tasks.Domain;

public class Task : Entity, IAggregateRoot
{
    public Guid Id { get; init; }
    public Title Title { get; private set; }
    public Notification Notification { get; private set; }
    
    public DateTime UtcTime { get; init; }
    public DateTime ModifiedUtcTime { get; private set; }
}