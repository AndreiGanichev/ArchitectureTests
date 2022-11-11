using ArchUnitNET.xUnit;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ToDoList.ArchitectureTests.ArchitectureExplorer;

namespace ToDoList.ArchitectureTests.Modules;

public class ModulesTests
{
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Domain_ShouldNotHave_Dependency_ToOtherModules(string module)
    {
        var otherModules = ArchitectureExplorer.Modules.Except(module);

        Types().That()
            .Are(DomainLayerOf(module))
            .Should()
            .NotDependOnAny(otherModules)
            .Check(ToDoListArchitecture);
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Application_ShouldNotHave_Dependency_ToOtherModules(string module)
    {
        var otherModules = ArchitectureExplorer.Modules.Except(module);

        Types().That()
            .Are(ApplicationLayerOf(module))
            .Should()
            .NotDependOnAny(otherModules)
            .Check(ToDoListArchitecture);
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Infrastructure_Except_Gateway_ShouldNotHaveDependency_ToOtherModules(string module)
    {
        var otherModules = ArchitectureExplorer.Modules.Except(module);

        Types().That()
            .Are(InfrastructureLayerOf(module))
            .And()
            .AreNot(InfrastructureGatewayOf(module))
            .Should()
            .NotDependOnAny(otherModules)
            .Evaluate(ToDoListArchitecture);
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Gateway_ShouldHas_Dependency_ToApplicationContracts_Only(string module)
    {
        Types().That()
            .Are(InfrastructureGatewayOf(module))
            .Should()
            .OnlyDependOn(ApplicationContracts)
            .Check(ToDoListArchitecture);
    }
}