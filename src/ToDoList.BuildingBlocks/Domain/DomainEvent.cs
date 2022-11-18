namespace ToDoList.BuildingBlocks;

public abstract class DomainEvent
{
    public Guid Id { get; }

    public DateTime UtcTime { get; }

    protected DomainEvent()
    {
        Id = Guid.NewGuid();
        UtcTime = DateTime.UtcNow;
    }
}