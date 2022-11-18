using MediatR;

namespace ToDoList.Tasks.Application.Contracts;

public class TaskCreatedIntegrationEvent : INotification
{
    public Guid TaskId { get; }
    public Guid AuthorId { get; }
    public string Title { get; }
    public DateOnly Date { get; }
    public DateTimeOffset RemindAt { get; }

    public TaskCreatedIntegrationEvent(Guid taskId, Guid authorId, string title, DateOnly date, DateTimeOffset remindAt)
    {
        TaskId = taskId;
        AuthorId = authorId;
        Title = title;
        Date = date;
        RemindAt = remindAt;
    }
}