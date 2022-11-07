using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ToDoList.NetArchTest.Api;

public class LayersTests
{
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Api_ShouldNotHave_Dependencies_ToDomain(string module)
    {
        Types.InNamespace(ArchitectureExplorer.ApiNamespace)
            .ShouldNot()
            .HaveDependencyOnAny(ArchitectureExplorer.Modules.DomainOf(module))
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
    
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Api_CanHave_Dependencies_ToApplicationContracts_Only(string module)
    { 
        Types.InNamespace(ArchitectureExplorer.ApiNamespace)
            .That().HaveDependencyOnAny(ArchitectureExplorer.Modules.ApplicationOf(module))
            .Should().HaveDependencyOn("")
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Api_Can_HaveDependencies_ToInfrastructureConfiguration_Only()
    {
    }
}