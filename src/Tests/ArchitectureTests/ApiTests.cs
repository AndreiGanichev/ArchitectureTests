using ArchUnitNET.Domain;
using ArchUnitNET.Fluent;
using ArchUnitNET.xUnit;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ToDoList.ArchitectureTests.Explorers.ArchitectureExplorer;

namespace ToDoList.ArchitectureTests;

public class ApiTests
{
    private static readonly IObjectProvider<Class> Controllers =
        Classes()
            .That().Are(PresentationLayer)
            .And()
            .AreAssignableTo(typeof(ControllerBase));
    
    [Fact]
    public void AllEndpoints_ShouldHave_Authorization()
    {
        IArchRule methodAuthorizedRule = 
            MethodMembers().That()
                .AreDeclaredIn(Controllers)
                .And().HaveAnyAttributes(typeof(HttpMethodAttribute))
                .Should().HaveAnyAttributes(typeof(AuthorizeAttribute));
        
        IArchRule controllerAuthorizedRule = Classes()
            .That().Are(Controllers)
            .Should().HaveAnyAttributes(typeof(AuthorizeAttribute));

        methodAuthorizedRule.Or(controllerAuthorizedRule)
            .Check(ToDoListArchitecture);
    }
}