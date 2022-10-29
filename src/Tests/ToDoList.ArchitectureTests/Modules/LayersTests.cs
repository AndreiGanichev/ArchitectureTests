using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ToDoList.ArchitectureTests.Modules;

public class LayersTests
{
    [Fact]
    public void DomainLayer_DoesNotHaveDependency_ToApplicationLayer()
    {
        Types.InNamespace("ToDoList.Tasks.Domain")
            .ShouldNot()
            .HaveDependencyOnAny("ToDoList.Tasks.Application")
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void DomainLayer_DoesNotHaveDependency_ToInfrastructureLayer()
    {
        Types.InNamespace("ToDoList.Tasks.Domain")
            .ShouldNot()
            .HaveDependencyOn("ToDoList.Tasks.Infrastructure")
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void ApplicationLayer_DoesNotHaveDependency_ToInfrastructureLayer()
    {
        Types.InNamespace("ToDoList.Tasks.Application")
            .ShouldNot()
            .HaveDependencyOn("ToDoList.Tasks.Infrastructure")
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
}