using MediatR;
using ToDoList.Notifications.Domain;

namespace ToDoList.Notifications.Application.Contracts;

public class AddNotificationCommand : IRequest
{
    public Guid Id { get; }

    public Guid UserId { get; }
    public string Body { get; }
    public Channel Channel { get; }
    public DateTimeOffset At { get; }

    public AddNotificationCommand(Guid id, string body, Channel channel, DateTimeOffset at, Guid userId)
    {
        Id = id;
        Body = body;
        Channel = channel;
        At = at;
        UserId = userId;
    }
}