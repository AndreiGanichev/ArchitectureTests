using ToDoList.BuildingBlocks.Domain;
using ToDoList.Notifications.Domain.DomainEvents;

namespace ToDoList.Notifications.Domain;

public class Notification : Entity, IAggregateRoot
{
    public Guid Id { get; }
    public Guid TaskId { get; }
    public Body Body { get; private set; }
    public Status Status { get; private set; }
    public Addressee Addressee { get; }
    public DateTimeOffset At { get; private set; }

    private Notification(Guid id, Guid taskId, Addressee addressee, Body body, Status status, DateTimeOffset at)
    {
        Id = id;
        Body = body;
        Status = status;
        At = at;
        TaskId = taskId;
        Addressee = addressee;

        AddDomainEvent(new NotificationCreatedDomainEvent(id, addressee, body, at));
    }

    public static Notification Create(Guid taskId, Addressee addressee, Body body, DateTimeOffset at) =>
        new(
            Guid.NewGuid(),
            taskId, 
            addressee, 
            body, 
            Status.Active, 
            at);
}