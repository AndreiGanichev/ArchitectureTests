using MediatR;

namespace ToDoList.BuildingBlocks.Domain;

public abstract class DomainEvent : INotification
{
    public Guid Id { get; }

    public DateTime UtcTime { get; }

    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        UtcTime = DateTime.UtcNow;
    }
}