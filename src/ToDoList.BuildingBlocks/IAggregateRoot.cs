namespace ToDoList.BuildingBlocks;

public interface IAggregateRoot
{
    public Guid Id { get; init; }
}