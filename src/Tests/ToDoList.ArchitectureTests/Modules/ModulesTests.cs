using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ToDoList.NetArchTest.Modules;

public class ModulesTests
{
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainLayer_ShouldNotHave_Dependency_ToOtherModules(string module)
    {
        var otherModules = ArchitectureExplorer.Modules.Except(module);

        foreach (var domain in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InNamespace(domain)
                .ShouldNot()
                .HaveDependencyOnAny(otherModules)
                .GetResult()
                .FailingTypes.Should().BeNullOrEmpty();
        }
    }
    
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void ApplicationLayer_ShouldNotHave_Dependency_ToOtherModules(string module)
    {
        var otherModules = ArchitectureExplorer.Modules.Except(module);

        foreach (var application in ArchitectureExplorer.Modules.ApplicationOf(module))
        {
            Types.InNamespace(application)
                .ShouldNot()
                .HaveDependencyOnAny(otherModules)
                .GetResult()
                .FailingTypes.Should().BeNullOrEmpty();
        }
    }
    
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void InfrastructureLayer_Except_InfrastructureGateway_ShouldNotHaveDependency_ToOtherModules(string module)
    {
        var otherModules = ArchitectureExplorer.Modules.Except(module);

        foreach (var infrastructure in ArchitectureExplorer.Modules.InfrastructureOf(module))
        {
            Types.InNamespace(infrastructure)
                .That()
                .HaveDependencyOnAny(otherModules)
                .Should()
                .ResideInNamespace(ArchitectureExplorer.Modules.InfrastructureGatewayOf(module))
                .GetResult()
                .FailingTypes.Should().BeNullOrEmpty();
        }
    }
    
    [Fact]
    public void InfrastructureModules_ShouldHas_Dependency_ToApplicationContracts_Only()
    {
    }
}