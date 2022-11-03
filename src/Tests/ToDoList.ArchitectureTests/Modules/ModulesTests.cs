using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ToDoList.ArchitectureTests.Modules;

public class ModulesTests
{
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainLayer_DoesNotHaveDependency_ToOtherModules(string module)
    {
        var otherModules = ArchitectureExplorer.Modules.Except(module);

        foreach (var domain in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InNamespace(domain)
                .ShouldNot()
                .HaveDependencyOnAny(otherModules)
                .GetResult()
                .IsSuccessful.Should().BeTrue();
        }
    }
    
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void ApplicationLayer_DoesNotHaveDependency_ToOtherModules(string module)
    {
        var otherModules = ArchitectureExplorer.Modules.Except(module);

        foreach (var application in ArchitectureExplorer.Modules.ApplicationOf(module))
        {
            Types.InNamespace(application)
                .ShouldNot()
                .HaveDependencyOnAny(otherModules)
                .GetResult()
                .IsSuccessful.Should().BeTrue();
        }
    }
    
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void InfrastructureLayer_Except_InfrastructureModules_DoesNotHaveDependency_ToOtherModules(string module)
    {
        var otherModules = ArchitectureExplorer.Modules.Except(module);

        foreach (var infrastructure in ArchitectureExplorer.Modules.InfrastructureOf(module))
        {
            Types.InNamespace(infrastructure)
                .That()
                .HaveDependencyOnAny(otherModules)
                .Should()
                .ResideInNamespace(ArchitectureExplorer.Modules.InfrastructureModulesOf(module))
                .GetResult()
                .IsSuccessful.Should().BeTrue();
        }
    }
    
    [Fact]
    public void InfrastructureModules_HasDependency_ToContracts_Only()
    {
    }
}