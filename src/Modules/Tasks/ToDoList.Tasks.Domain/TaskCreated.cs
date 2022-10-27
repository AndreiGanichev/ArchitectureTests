using ToDoList.BuildingBlocks;

namespace ToDoList.Tasks.Domain;

public class TaskCreated : DomainEvent
{
    public Guid TaskId { get; init; }
    public Title Title { get; init; }
    public Notification Notification { get; init; }
    
    
}