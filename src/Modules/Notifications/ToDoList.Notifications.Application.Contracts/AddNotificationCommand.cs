using MediatR;

namespace ToDoList.Notifications.Application.Contracts;

public class AddNotificationCommand : IRequest
{
    public Guid TaskId { get; }
    public Guid AddresseeId { get; }
    public string Body { get; }
    public DateTimeOffset At { get; }

    public AddNotificationCommand(Guid taskId, Guid addresseeId, string body, DateTimeOffset at)
    {
        TaskId = taskId;
        Body = body;
        At = at;
        AddresseeId = addresseeId;
    }
}