using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ToDoList.ArchitectureTests.Modules;

public class ModulesTests
{
    [Fact]
    public void DomainLayer_DoesNotHaveDependency_ToOtherModules()
    {
        // for each module
        Types.InNamespace("ToDoList.Tasks.Domain")
            .ShouldNot()
            .HaveDependencyOnAny("ToDoList.Notifications")
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void ApplicationLayer_DoesNotHaveDependency_ToOtherModules()
    {
        // for each module
        Types.InNamespace("ToDoList.Tasks.Application")
            .ShouldNot()
            .HaveDependencyOnAny("ToDoList.Notifications")
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void InfrastructureLayer_Except_InfrastructureModules_DoesNotHaveDependency_ToOtherModules()
    {
        // for each module
        var types = Types.InNamespace("ToDoList.Notifications.Infrastructure")
            .ShouldNot()
            .HaveDependencyOn("ToDoList.Tasks")
            .GetResult().FailingTypes;

        types?.Should().AllSatisfy(t => t.Namespace.Should().StartWith("ToDoList.Infrastructure.Modules"));
    }
    
    [Fact]
    public void InfrastructureModules_HasDependency_ToContracts_Only()
    {
        Types.InAssembly(Assembly.Load("ToDoList.Notifications.Infrastructure.Modules"))
            .ShouldNot()
            .HaveDependencyOnAny(
                "ToDoList.Notifications.Domain",
                "ToDoList.Notifications.Application.Internals",
                "ToDoList.Notifications.Infrastructure")
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
}