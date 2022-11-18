using MediatR;

namespace ToDoList.Tasks.Application.Contracts;

public class AddTaskCommand : IRequest<Guid>
{
    public Guid UserId { get; }
    public string Title { get; }
    public DateOnly Date { get; }
    public DateTimeOffset RemindAt { get; }

    public AddTaskCommand(Guid userId, string title, DateOnly date, DateTimeOffset remindAt)
    {
        Title = title;
        Date = date;
        RemindAt = remindAt;
        UserId = userId;
    }
}