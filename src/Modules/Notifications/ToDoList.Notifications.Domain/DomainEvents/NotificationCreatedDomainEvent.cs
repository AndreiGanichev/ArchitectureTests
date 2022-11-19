using ToDoList.BuildingBlocks.Domain;

namespace ToDoList.Notifications.Domain.DomainEvents;

public class NotificationCreatedDomainEvent : DomainEvent
{
    public Guid Id { get; }
    public Body Body { get; }
    public Addressee Addressee { get; }
    public DateTimeOffset At { get; }

    public NotificationCreatedDomainEvent(Guid id, Addressee addressee, Body body, DateTimeOffset at)
    {
        Id = id;
        Body = body;
        At = at;
        Addressee = addressee;
    }
}