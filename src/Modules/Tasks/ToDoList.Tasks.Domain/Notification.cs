using ToDoList.BuildingBlocks;

namespace ToDoList.Tasks.Domain;

public class Notification : ValueObject
{
    public NotificationChannel Channel { get; }
    public DateTimeOffset At { get; }
}