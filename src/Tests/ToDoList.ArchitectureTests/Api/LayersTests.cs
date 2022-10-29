using System.Linq;
using FluentAssertions;
using NetArchTest.Rules;
using ToDoList.ArchitectureTests.Architecture;
using Xunit;

namespace ToDoList.ArchitectureTests.Api;

public class LayersTests
{
    [Fact]
    public void Api_Should_Not_Have_Dependencies_To_Domain()
    {
        Types.InNamespace(Architecture.Architecture.ApiNamespace)
            .ShouldNot()
            .HaveDependencyOnAny(Architecture.Architecture.Modules.NamespacesOf(Layer.Domain))
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Api_Can_Have_Dependencies_To_ApplicationContracts_Only()
    { 
        Types.InNamespace(Architecture.Architecture.ApiNamespace)
            .ShouldNot()
            .HaveDependencyOnAny(Architecture.Architecture.Modules.NamespacesOf(Layer.Domain, Architecture.Architecture.ContractsProjectName))
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
    
    [Fact]
    public void Api_Can_Have_Dependencies_To_InfrastructureConfiguration_Only()
    {
        Types.InNamespace(Architecture.Architecture.ApiNamespace)
            .ShouldNot()
            .HaveDependencyOnAny(Architecture.Architecture.Modules.NamespacesOf(Layer.Domain, Architecture.Architecture.ConfigurationProjectName))
            .GetResult()
            .IsSuccessful.Should().BeTrue();
    }
}