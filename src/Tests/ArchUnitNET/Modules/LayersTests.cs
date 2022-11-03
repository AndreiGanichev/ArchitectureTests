using ArchUnitNET.xUnit;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ToDoList.ArchUnitNET.ArchitectureExplorer;

namespace ToDoList.ArchUnitNET.Modules;

public class LayersTests
{
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainLayer_DoesNotHaveDependency_ToApplicationLayer(string module)
    {
        Types().That()
            .Are(DomainLayerOf(module))
            .Should()
            .NotDependOnAny(ApplicationLayerOf(module))
            .Check(ToDoListArchitecture);
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainLayer_DoesNotHaveDependency_ToInfrastructureLayer(string module)
    {
        Types().That()
            .Are(DomainLayerOf(module))
            .Should()
            .NotDependOnAny(InfrastructureLayerOf(module))
            .Check(ToDoListArchitecture);
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void ApplicationLayer_DoesNotHaveDependency_ToInfrastructureLayer(string module)
    {
        Types().That()
            .Are(ApplicationLayerOf(module))
            .Should()
            .NotDependOnAny(InfrastructureLayerOf(module))
            .Check(ToDoListArchitecture);
    }
}