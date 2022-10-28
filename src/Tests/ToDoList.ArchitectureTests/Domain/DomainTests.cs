using Xunit;

namespace ToDoList.ArchitectureTests.Domain;

public class DomainTests
{
    [Fact]
    public void DomainEvent_Should_Be_Immutable()
    {
    }

    [Fact]
    public void ValueObject_Should_Be_Immutable()
    {
    }
    
    [Fact]
    public void Entity_Which_Is_Not_Aggregate_Root_Cannot_Have_Public_Members()
    {
    }

    [Fact]
    public void DomainEvent_Should_Have_DomainEventPostfix()
    {
    }
}