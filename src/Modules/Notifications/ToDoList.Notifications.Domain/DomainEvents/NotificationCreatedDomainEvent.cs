using ToDoList.BuildingBlocks;

namespace ToDoList.Notifications.Domain.DomainEvents;

public class NotificationCreatedDomainEvent : DomainEvent
{
    public Guid Id { get; }
    public Body Body { get; }
    public Addressee Addressee { get; }
    public Channel Channel { get; }
    public DateTimeOffset At { get; }

    public NotificationCreatedDomainEvent(Guid id, Addressee addressee, Body body, Channel channel, DateTimeOffset at)
    {
        Id = id;
        Body = body;
        Channel = channel;
        At = at;
        Addressee = addressee;
    }
}