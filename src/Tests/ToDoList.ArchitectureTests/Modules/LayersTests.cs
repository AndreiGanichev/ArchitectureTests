using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ToDoList.NetArchTest.Modules;

public class LayersTests
{
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainLayer_DoesNotHaveDependency_ToApplicationLayer(string module)
    {
        foreach (var domain in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InNamespace(domain)
                .ShouldNot()
                .HaveDependencyOnAny(ArchitectureExplorer.Modules.ApplicationOf(module))
                .GetResult()
                .FailingTypes.Should().BeEmpty();
        }
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainLayer_DoesNotHaveDependency_ToInfrastructureLayer(string module)
    {
        foreach (var domain in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InNamespace(domain)
                .ShouldNot()
                .HaveDependencyOnAny(ArchitectureExplorer.Modules.InfrastructureOf(module))
                .GetResult()
                .FailingTypes.Should().BeEmpty();
        }
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void ApplicationLayer_DoesNotHaveDependency_ToInfrastructureLayer(string module)
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