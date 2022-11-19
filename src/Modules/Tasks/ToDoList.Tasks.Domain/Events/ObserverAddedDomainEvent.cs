using ToDoList.BuildingBlocks.Domain;

namespace ToDoList.Tasks.Domain.Events;

public class ObserverAddedDomainEvent : DomainEvent
{
    public Guid TaskId { get; }
    public Guid ObserverId { get; }
    public ObserverRole ObserverRole { get; }

    public ObserverAddedDomainEvent(Guid taskId, Guid observerId, ObserverRole observerRole)
    {
        TaskId = taskId;
        ObserverId = observerId;
        ObserverRole = observerRole;
    }
}