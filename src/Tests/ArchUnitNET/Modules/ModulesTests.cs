using ArchUnitNET.xUnit;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ToDoList.ArchUnitNET.ArchitectureExplorer;

namespace ToDoList.ArchUnitNET.Modules;

public class ModulesTests
{
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainLayer_ShouldNotHave_Dependency_ToOtherModules(string module)
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
    public void ApplicationLayer_ShouldNotHave_Dependency_ToOtherModules(string module)
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
    public void InfrastructureLayer_Except_InfrastructureModules_ShouldNotHaveDependency_ToOtherModules(string module)
    {
        var otherModules = ArchitectureExplorer.Modules.Except(module);

        Types().That()
            .Are(InfrastructureLayerOf(module))
            .And()
            .AreNot(InfrastructureModulesOf(module))
            .Should()
            .NotDependOnAny(otherModules)
            .Evaluate(ToDoListArchitecture);
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void InfrastructureModules_ShouldHas_Dependency_ToApplicationContracts_Only(string module)
    {
        Types().That()
            .Are(InfrastructureModulesOf(module))
            .Should()
            .OnlyDependOn(ApplicationContracts)
            .Check(ToDoListArchitecture);
    }
}