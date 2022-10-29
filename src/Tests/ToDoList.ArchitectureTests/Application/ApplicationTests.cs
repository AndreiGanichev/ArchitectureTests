using System.Reflection;
using FluentAssertions;
using MediatR;
using NetArchTest.Rules;
using ToDoList.ArchitectureTests.Architecture;
using ToDoList.Notifications.Application.Contracts;
using ToDoList.Tasks.Application.Contracts;
using Xunit;

namespace ToDoList.ArchitectureTests.Application;

public class ApplicationTests
{
    [Fact]
    public void Command_And_Query_Handlers_Should_Not_Be_Public()
    {
        foreach (var applicationNamespace in Architecture.Architecture.Modules.NamespacesOf(Layer.Application))
        {
            Types.InNamespace(applicationNamespace)
                .That()
                .ImplementInterface(typeof(IRequestHandler<>))
                .ShouldNot().BePublic()
                .GetResult()
                .FailingTypes.Should().BeNullOrEmpty();
        }
    }

    [Fact]
    public void Command_And_Query_Should_Be_Immutable()
    {
        Types.InAssemblies(new[]
            {
                typeof(AddTaskCommand).Assembly,
                typeof(AddNotificationCommand).Assembly
            })
            .That()
            .ImplementInterface(typeof(IRequest))
            .Or()
            .ImplementInterface(typeof(IRequest))
            .ShouldNot().BeMutable()
            .GetResult()
            .FailingTypes.Should().BeNullOrEmpty();
    }

    [Fact]
    public void RequestHandler_Should_Have_Name_With_Postfix_Handler()
    {
        Types.InAssemblies(new[]
            {
                Assembly.Load("ToDoList.Tasks.Application.Internals"), 
                Assembly.Load("ToDoList.Notifications.Application.Internals")
            })
            .That()
            .ImplementInterface(typeof(IRequestHandler<>))
            .Should().HaveNameEndingWith("Handler")
            .GetResult()
            .FailingTypes.Should().BeNullOrEmpty();
    }
}