using ArchUnitNET.xUnit;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ToDoList.ArchitectureTests.ArchitectureExplorer;

namespace ToDoList.ArchitectureTests.Api;

public class LayersTests
{
    [Fact]
    public void Api_ShouldNotHave_Dependencies_ToDomain()
    {
        Types().That()
            .Are(PresentationLayer)
            .Should()
            .NotDependOnAny(DomainLayers)
            .Check(ToDoListArchitecture);
    }
    
    [Fact]
    public void Api_CanHave_Dependencies_ToApplicationContracts_Only()
    {
        Types().That()
            .Are(PresentationLayer)
            .Should()
            .OnlyDependOn(ApplicationContractsOrExclusions)
            .Check(ToDoListArchitecture);
    }
    
    [Fact]
    public void Api_Can_HaveDependencies_ToInfrastructureConfiguration_Only()
    {

    }
}