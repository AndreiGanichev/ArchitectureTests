using ToDoList.BuildingBlocks;

namespace ToDoList.Tasks.Domain;

public class Reminder : ValueObject
{
    public ReminderChannel Channel { get; }
    public DateTimeOffset At { get; }

    public Reminder(ReminderChannel channel, DateTimeOffset at)
    {
        Channel = channel;
        At = at;
    }
}