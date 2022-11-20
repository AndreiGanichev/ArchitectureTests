using ArchUnitNET.xUnit;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ToDoList.ArchUnitNET.ArchitectureExplorer;

namespace ToDoList.ArchUnitNET.Modules;

public class LayersTests
{
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Domain_ShouldNotHave_Dependency_ToApplication(string module)
    {
        Types().That()
            .Are(DomainLayerOf(module))
            .Should()
            .NotDependOnAny(ApplicationLayerOf(module))
            .Check(ToDoListArchitecture);
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Domain_ShouldNotHave_Dependency_ToInfrastructure(string module)
    {
        Types().That()
            .Are(DomainLayerOf(module))
            .Should()
            .NotDependOnAny(InfrastructureLayerOf(module))
            .Check(ToDoListArchitecture);
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Application_ShouldNotHave_Dependency_ToInfrastructure(string module)
    {
        Types().That()
            .Are(ApplicationLayerOf(module))
            .Should()
            .NotDependOnAny(InfrastructureLayerOf(module))
            .Check(ToDoListArchitecture);
    }
}