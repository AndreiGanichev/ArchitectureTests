using ToDoList.BuildingBlocks;

namespace ToDoList.Tasks.Domain.Events;

public class TaskCreatedDomainEvent : DomainEvent
{
    public Guid TaskId { get; }
    public Guid AuthorId { get; }
    public Title Title { get; }
    public DateOnly Date { get; }
    public DateTimeOffset RemindAt { get; }

    public TaskCreatedDomainEvent(Guid taskId, Guid authorId, Title title, DateOnly date, DateTimeOffset remindAt)
    {
        TaskId = taskId;
        Title = title;
        AuthorId = authorId;
        Date = date;
        RemindAt = remindAt;
    }
}