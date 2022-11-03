using FluentAssertions;
using NetArchTest.Rules;
using Xunit;

namespace ToDoList.ArchitectureTests.Api;

public class LayersTests
{
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Api_Should_Not_Have_Dependencies_To_Domain(string module)
    {
        Types.InNamespace(ArchitectureExplorer.ApiNamespace)
            .ShouldNot()
            .HaveDependencyOnAny(ArchitectureExplorer.Modules.DomainOf(module))
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
    
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Api_Can_Have_Dependencies_To_ApplicationContracts_Only(string module)
    { 
        Types.InNamespace(ArchitectureExplorer.ApiNamespace)
            .That().HaveDependencyOnAny(ArchitectureExplorer.Modules.ApplicationOf(module))
            .Should().HaveDependencyOn("")
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Api_Can_Have_Dependencies_To_InfrastructureConfiguration_Only()
    {
    }
}