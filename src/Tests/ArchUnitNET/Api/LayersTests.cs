using ArchUnitNET.xUnit;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ToDoList.ArchUnitNET.ArchitectureExplorer;

namespace ToDoList.ArchUnitNET.Api;

public class LayersTests
{
    [Fact]
    public void Api_Should_Not_Have_Dependencies_To_Domain()
    {
        Types().That()
            .Are(PresentationLayer)
            .Should()
            .NotDependOnAny(DomainLayers)
            .Check(ToDoListArchitecture);
    }
    
    [Fact]
    public void Api_Can_Have_Dependencies_To_ApplicationContracts_Only()
    {
        Types().That()
            .Are(PresentationLayer)
            .Should()
            .OnlyDependOn(ApplicationContractsOrExclusions)
            .Check(ToDoListArchitecture);
    }
    
    [Fact]
    public void Api_Can_Have_Dependencies_To_InfrastructureConfiguration_Only()
    {

    }
}