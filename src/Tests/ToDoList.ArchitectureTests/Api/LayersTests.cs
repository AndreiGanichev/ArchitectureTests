using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ToDoList.ArchitectureTests.Api;

public class LayersTests
{
    [Fact]
    public void Api_Should_Not_Have_Dependencies_To_Domain()
    {
        Types.InAssembly(Architecture.Architecture.ApiAssembly)
            .Should()
            .NotHaveDependencyOnAny(
                "ToDoList.Tasks.Domain",
                "ToDoList.Notifications.Domain")
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Api_Can_Have_Dependencies_To_ApplicationContracts_Only()
    { 
        Types.InAssembly(Architecture.Architecture.ApiAssembly)
            .Should()
            .NotHaveDependencyOnAny(
                "ToDoList.Tasks.Application.Internals", //ToDo: how add exceptions to specify application layer and Contracts as exception? may be custom rule
                "ToDoList.Notifications.Application.Internals")
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Api_Can_Have_Dependencies_To_InfrastructureConfiguration_Only()
    {
        Types.InAssembly(Architecture.Architecture.ApiAssembly)
            .Should()
            .NotHaveDependencyOnAny(
                "ToDoList.Tasks.Infrastructure.Database",
                "ToDoList.Tasks.Infrastructure.MessageBus",
                "ToDoList.Notifications.Infrastructure.Database",
                "ToDoList.Notifications.Infrastructure.MessageBus",
                "ToDoList.Notifications.Infrastructure.Modules",
                "ToDoList.Notifications.Infrastructure.Telegram")
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
}