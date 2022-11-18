using ToDoList.Tasks.Domain;

namespace ToDoList.Tasks.Application.Contracts.GetTask;

public class TaskDto
{
    public Guid Id { get; }
    public Guid AuthorId { get; }
    public string Title { get; }
    public DateOnly Date  { get; }
    public DateTimeOffset RemindAt { get; }

    public TaskDto(Guid id, Guid authorId, string title, DateOnly date, DateTimeOffset remindAt)
    {
        Id = id;
        AuthorId = authorId;
        Title = title;
        Date = date;
        RemindAt = remindAt;
    }
}