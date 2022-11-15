using ArchUnitNET.xUnit;
using ToDoList.ArchitectureTests.Explorers;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ToDoList.ArchitectureTests.Explorers.ArchitectureExplorer;

namespace ToDoList.ArchitectureTests;

public class ModuleTests
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
    
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Domain_ShouldNotHave_Dependency_ToOtherModules(string module)
    {
        var otherModules = ArchitectureExplorer.Modules.Except(module);

        Types().That()
            .Are(DomainLayerOf(module))
            .Should()
            .NotDependOnAny(otherModules, true)
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
            .NotDependOnAny(otherModules, true)
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
            .NotDependOnAny(otherModules, true)
            .Check(ToDoListArchitecture);
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
}