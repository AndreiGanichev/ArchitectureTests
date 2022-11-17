using ToDoList.BuildingBlocks;

namespace ToDoList.Tasks.Domain;

public class TaskCreatedDomainEvent : DomainEvent
{
    public Guid TaskId { get; }
    public Title Title { get; }
    public Reminder Reminder { get; }
}