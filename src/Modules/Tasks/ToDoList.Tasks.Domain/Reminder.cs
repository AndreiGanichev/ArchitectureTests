using ToDoList.BuildingBlocks;

namespace ToDoList.Tasks.Domain;

public class Reminder : ValueObject
{
    public ReminderChannel Channel { get; }
    public DateTimeOffset At { get; }
}