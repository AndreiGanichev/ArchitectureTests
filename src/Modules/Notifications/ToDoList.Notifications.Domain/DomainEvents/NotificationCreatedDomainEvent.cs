using ToDoList.BuildingBlocks.Domain;

namespace ToDoList.Notifications.Domain.DomainEvents;

public class NotificationCreatedDomainEvent : DomainEvent
{
    public Guid NotificationId { get; }
    public Body Body { get; }
    public Addressee Addressee { get; }
    public DateTimeOffset At { get; }

    public NotificationCreatedDomainEvent(Guid notificationId, Addressee addressee, Body body, DateTimeOffset at)
    {
        NotificationId = notificationId;
        Body = body;
        At = at;
        Addressee = addressee;
    }
}