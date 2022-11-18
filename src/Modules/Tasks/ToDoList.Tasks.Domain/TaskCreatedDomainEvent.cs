using ToDoList.BuildingBlocks;

namespace ToDoList.Tasks.Domain;

public class TaskCreatedDomainEvent : DomainEvent
{
    public Guid TaskId { get; }
    public Title Title { get; }
    public Reminder Reminder { get; }

    public TaskCreatedDomainEvent(Guid taskId, Title title, Reminder reminder)
    {
        TaskId = taskId;
        Title = title;
        Reminder = reminder;
    }
}