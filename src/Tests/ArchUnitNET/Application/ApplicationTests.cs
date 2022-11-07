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
    public void RequestHandler_ShouldNotBe_Public()
    {
        Classes().That().Are(RequestHandlers).Should().NotBePublic().Check(ToDoListArchitecture);
    }
    
    [Fact]
    public void RequestHandler_ShouldBe_Sealed()
    {
        Classes().That().Are(RequestHandlers).Should().BeSealed().Check(ToDoListArchitecture);
    }

    [Fact]
    public void RequestHandler_ShouldHave_NameWithPostfix_Handler()
    {
        Classes()
            .That().Are(RequestHandlers)
            .Should().HaveNameEndingWith("Handler")
            .Check(ToDoListArchitecture);
    }
    
    [Fact]
    public void Request_ShouldBe_Immutable()
    {
        Classes().That().Are(Requests).Should().NotBePublic();
    }
    
    [Fact]
    public void Request_ShouldHave_NameWithPostfix_QueryOrCommand()
    {
        Classes().That().Are(Requests)
            .Should().HaveNameEndingWith("Query")
            .OrShould().HaveNameEndingWith("Command")
            .Check(ToDoListArchitecture);
    }
}