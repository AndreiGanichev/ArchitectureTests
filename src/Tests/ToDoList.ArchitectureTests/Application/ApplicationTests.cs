using System.Reflection;
using FluentAssertions;
using MediatR;
using NetArchTest.Rules;
using Xunit;

namespace ToDoList.NetArchTest.Application;

public class ApplicationTests
{
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void RequestHandler_Should_Not_Be_Public(string module)
    {
        Types.InNamespace(ArchitectureExplorer.Modules.ApplicationInternalsOf(module))
                .That()
                .ImplementInterface(typeof(IRequestHandler<>))
                .Or()
                .ImplementInterface(typeof(IRequestHandler<,>))
                .ShouldNot().BePublic()
                .GetResult()
                .FailingTypes.Should().BeNullOrEmpty();
    }
    
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void RequestHandler_Should_Be_Sealed(string module)
    {
        Types.InNamespace(ArchitectureExplorer.Modules.ApplicationInternalsOf(module))
            .That()
            .ImplementInterface(typeof(IRequestHandler<>))
            .Or()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .ShouldNot().BePublic()
            .GetResult()
            .FailingTypes.Should().BeNullOrEmpty();
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void RequestHandler_Should_Have_Name_With_Postfix_Handler(string module)
    {
        Types.InAssembly(Assembly.Load(ArchitectureExplorer.Modules.ApplicationInternalsOf(module)))
            .That()
            .ImplementInterface(typeof(IRequestHandler<>))
            .Or()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .Should().HaveNameEndingWith("Handler")
            .GetResult()
            .FailingTypes.Should().BeNullOrEmpty();
    }
    
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Request_Should_Be_Immutable(string module)
    {
        Types.InNamespace(ArchitectureExplorer.Modules.ApplicationContractsOf(module))
            .That()
            .ImplementInterface(typeof(IRequest))
            .Or()
            .ImplementInterface(typeof(IRequest<>))
            .ShouldNot().BeMutable()
            .GetResult()
            .FailingTypes.Should().BeNullOrEmpty();
    }
    
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Request_Should_Have_Name_With_Postfix_QueryOrCommand(string module)
    {
        Types.InNamespace(ArchitectureExplorer.Modules.ApplicationContractsOf(module))
            .That()
            .ImplementInterface(typeof(IRequest))
            .Or()
            .ImplementInterface(typeof(IRequest<>))
            .Should()
            .HaveNameEndingWith("Query")
            .Or().HaveNameEndingWith("Command")
            .GetResult()
            .FailingTypes.Should().BeNullOrEmpty();
    }
}