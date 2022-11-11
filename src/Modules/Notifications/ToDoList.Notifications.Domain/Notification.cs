using ToDoList.BuildingBlocks;
using ToDoList.Tasks.Domain;

namespace ToDoList.Notifications.Domain;

public class Notification : Entity, IAggregateRoot
{
    public Guid Id { get; }
    public string Body { get; }
}