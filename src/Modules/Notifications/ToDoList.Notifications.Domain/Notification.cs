using ToDoList.BuildingBlocks.Domain;
using ToDoList.Notifications.Domain.DomainEvents;

namespace ToDoList.Notifications.Domain;

public class Notification : Entity, IAggregateRoot
{
    public Guid Id { get; }
    public Body Body { get; private set; }
    public Status Status { get; private set; }
    public Channel Channel { get; private set; }
    public Addressee Addressee { get; }
    public DateTimeOffset At { get; private set; }

    private Notification(Guid id, Addressee addressee, Body body, Status status, Channel channel, DateTimeOffset at)
    {
        Id = id;
        Body = body;
        Status = status;
        Channel = channel;
        At = at;
        Addressee = addressee;

        AddDomainEvent(new NotificationCreatedDomainEvent(id, addressee, body, channel, at));
    }

    public static Notification Create(Guid id, Addressee addressee, Body body, Channel channel, DateTimeOffset at) =>
        new Notification(
            id,
            addressee,
            body,
            Status.Active,
            channel,
            at);
}