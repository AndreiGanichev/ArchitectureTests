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
    public void RequestHandler_ShouldNotBe_Public(string module)
    {
        Types.InAssembly(Assembly.Load(ArchitectureExplorer.Modules.ApplicationInternalsOf(module)))
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
    public void RequestHandler_ShouldBe_Sealed(string module)
    {
        Types.InAssembly(Assembly.Load(ArchitectureExplorer.Modules.ApplicationInternalsOf(module)))
            .That()
            .ImplementInterface(typeof(IRequestHandler<>))
            .Or()
            .ImplementInterface(typeof(IRequestHandler<,>))
            .Should().BeSealed()
            .GetResult()
            .FailingTypes.Should().BeNullOrEmpty();
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void RequestHandler_ShouldHave_NameWithPostfix_Handler(string module)
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
    public void Request_ShouldBe_Immutable(string module)
    {
        Types.InAssembly(Assembly.Load(ArchitectureExplorer.Modules.ApplicationContractsOf(module)))
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
        Types.InAssembly(Assembly.Load(ArchitectureExplorer.Modules.ApplicationContractsOf(module)))
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