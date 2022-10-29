using ToDoList.BuildingBlocks;

namespace ToDoList.Tasks.Domain;

public class TaskCreatedEvent : DomainEvent
{
    public Guid TaskId { get; }
    public Title Title { get; }
    public Notification Notification { get; }
}