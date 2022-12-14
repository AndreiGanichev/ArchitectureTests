using ArchUnitNET.xUnit;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ToDoList.ArchUnitNET.ArchitectureExplorer;

namespace ToDoList.ArchUnitNET.Modules;

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
    public void Infrastructure_Except_GatewayAndMessageBus_ShouldNotHave_Dependency_ToOtherModules(string module)
    {
        var otherModules = ArchitectureExplorer.Modules.Except(module);

        Types().That()
            .Are(InfrastructureLayerOf(module))
            .And()
            .AreNot(InfrastructureGatewayOrMessageBusOf(module))
            .Should()
            .NotDependOnAny(otherModules, true)
            .Check(ToDoListArchitecture);
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void GatewayAndMessageBus_ShouldHave_Dependency_ToModuleInterface_Only(string module)
    {
        foreach (var anotherModule in ArchitectureExplorer.Modules.Except(module))
        {
            Types().That()
                .Are(InfrastructureGatewayOrMessageBusOf(module))
                .Should().NotDependOnAny(ModuleExceptPublicInterface(anotherModule))
                .Check(ToDoListArchitecture);
        }
    }
    
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Api_ShouldHave_Dependencies_ToModuleInterface_Only(string module)
    {
        Types().That()
            .Are(PresentationLayer)
            .Should()
            .NotDependOnAny(ModuleExceptPublicInterface(module))
            .Check(ToDoListArchitecture);
    }
}