using ToDoList.BuildingBlocks;

namespace ToDoList.Tasks.Domain.Events;

public class ObserverRoleChangedDomainEvent : DomainEvent
{
    public Guid TaskId { get; }
    public Guid ObserverId { get; }
    public ObserverRole ObserverRole { get; }

    public ObserverRoleChangedDomainEvent(Guid taskId, Guid observerId, ObserverRole observerRole)
    {
        TaskId = taskId;
        ObserverId = observerId;
        ObserverRole = observerRole;
    }
}