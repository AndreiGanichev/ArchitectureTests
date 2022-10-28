using Xunit;

namespace ToDoList.ArchitectureTests.Modules;

public class LayersTests
{
    [Fact]
    public void DomainLayer_DoesNotHaveDependency_ToApplicationLayer()
    {
    }

    [Fact]
    public void DomainLayer_DoesNotHaveDependency_ToInfrastructureLayer()
    {
    }

    [Fact]
    public void ApplicationLayer_DoesNotHaveDependency_ToInfrastructureLayer()
    {
    }
}