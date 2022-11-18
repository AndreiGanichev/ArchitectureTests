using ToDoList.BuildingBlocks;
using ToDoList.Tasks.Domain.Events;

namespace ToDoList.Tasks.Domain;

public class Observer : Entity
{
    public Guid Id { get; }

    public Guid TaskId { get; }

    public ObserverRole Role { get; private set; }

    private Observer(Guid taskId, Guid observerId, ObserverRole role)
    {
        Id = observerId;
        TaskId = taskId;
        Role = role;
        TaskId = taskId;
        
        AddDomainEvent(new ObserverRoleChangedDomainEvent(TaskId, Id, role));

    }

    internal static Observer Create(Guid taskId, Guid observerId, ObserverRole role) => new(taskId, observerId, role);

    internal void ChangeRole(ObserverRole role)
  {
      Role = role;
      
      AddDomainEvent(new ObserverRoleChangedDomainEvent(TaskId, Id, role));
  }
}