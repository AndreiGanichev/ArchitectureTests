using ArchUnitNET.Domain;
using ArchUnitNET.xUnit;
using MediatR;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ToDoList.ArchUnitNET.ArchitectureExplorer;

namespace ToDoList.ArchUnitNET.Application;

public class ApplicationTests
{
    private static readonly IObjectProvider<Class> Requests =
        Classes()
            .That().Are(ApplicationContracts)
            .And()
            .ImplementInterface(typeof(IRequest<>));

    private static readonly IObjectProvider<Class> RequestHandlers =
        Classes()
            .That().Are(ApplicationInternals)
            .And()
            .ImplementInterface(typeof(IRequestHandler<>))
            .Or().ImplementInterface(typeof(IRequestHandler<,>));

            [Fact]
    public void RequestHandler_Should_Not_Be_Public()
    {
        Types().That().Are(RequestHandlers).Should().NotBePublic().Check(ToDoListArchitecture);
    }
    
    [Fact]
    public void RequestHandler_Should_Be_Sealed()
    {
        Types().That().Are(RequestHandlers).Should().NotBePublic();
    }

    [Fact]
    public void RequestHandler_Should_Have_Name_With_Postfix_Handler()
    {
        Types().That().Are(RequestHandlers).Should().HaveNameEndingWith("Handler");
    }
    
    [Fact]
    public void Request_Should_Be_Immutable()
    {
        Types().That().Are(Requests).Should().NotBePublic();
    }
    
    [Fact]
    public void Request_Should_Be_Have_Name_With_Postfix_QueryOrCommand()
    {
        Types().That().Are(Requests)
            .Should().HaveNameEndingWith("Query")
            .OrShould().HaveNameEndingWith("Command");
    }
}