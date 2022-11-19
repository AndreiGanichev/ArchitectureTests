namespace ToDoList.BuildingBlocks.Domain;

public interface IAggregateRoot
{
    public Guid Id { get; }
}