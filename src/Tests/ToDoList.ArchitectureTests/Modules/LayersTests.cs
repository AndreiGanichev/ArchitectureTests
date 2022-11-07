using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ToDoList.NetArchTest.Modules;

public class LayersTests
{
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainLayer_ShouldNotHave_Dependency_ToApplicationLayer(string module)
    {
        foreach (var domain in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InNamespace(domain)
                .ShouldNot()
                .HaveDependencyOnAny(ArchitectureExplorer.Modules.ApplicationOf(module))
                .GetResult()
                .FailingTypes.Should().BeNullOrEmpty();
        }
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainLayer_ShouldNotHave_Dependency_ToInfrastructureLayer(string module)
    {
        foreach (var domain in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InNamespace(domain)
                .ShouldNot()
                .HaveDependencyOnAny(ArchitectureExplorer.Modules.InfrastructureOf(module))
                .GetResult()
                .FailingTypes.Should().BeNullOrEmpty();
        }
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void ApplicationLayer_ShouldNotHave_Dependency_ToInfrastructureLayer(string module)
    {
        foreach (var application in ArchitectureExplorer.Modules.ApplicationOf(module))
        {
            Types.InNamespace(application)
                .ShouldNot()
                .HaveDependencyOnAny(ArchitectureExplorer.Modules.InfrastructureOf(module))
                .GetResult()
                .IsSuccessful.Should().BeTrue();
        }
    }
}