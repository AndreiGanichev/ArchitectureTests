using System;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;
using ToDoList.BuildingBlocks.Domain;
using Xunit;

namespace ToDoList.NetArchTest.Domain;

public class DomainTests
{
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainEvent_ShouldBe_Immutable(string module)
    {
        foreach (var assemblyName in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InAssembly(Assembly.Load(assemblyName))
                .That()
                .Inherit(typeof(DomainEvent))
                .ShouldNot().BeMutable()
                .GetResult().FailingTypes
                .Should().BeNullOrEmpty();
        }
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void ValueObject_ShouldBe_Immutable(string module)
    {
        foreach (var assemblyName in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InAssembly(Assembly.Load(assemblyName))
                .That()
                .Inherit(typeof(ValueObject))
                .ShouldNot().BeMutable()
                .GetResult().FailingTypes
                .Should().BeNullOrEmpty();
        }
    }
    
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Entities_DoNotHave_PublicSetters(string module)
    {
        var bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static |
                           BindingFlags.DeclaredOnly;
        
        foreach (var assemblyName in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InAssembly(Assembly.Load(assemblyName))
                .That()
                .Inherit(typeof(Entity))
                .GetTypes()
                .Where(t => t.GetProperties(bindingFlags).Any(p => p.SetMethod?.IsPublic ?? false))
                .Should().BeEmpty();
        }
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Entity_WhichIsNotAggregateRoot_ShouldNotHave_PublicMethods(string module)
    {
        var bindingFlags = BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static |
                           BindingFlags.DeclaredOnly;

        var isPropertyMethod = (MemberInfo m) => m.Name.StartsWith("get_", StringComparison.Ordinal)
                                                 || m.Name.StartsWith("set_", StringComparison.Ordinal);
        
        
        foreach (var assemblyName in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InAssembly(Assembly.Load(assemblyName))
                .That()
                .Inherit(typeof(Entity))
                .And().DoNotImplementInterface(typeof(IAggregateRoot))
                .GetTypes()
                .Where(t => t.GetMethods(bindingFlags).Any(m => !isPropertyMethod(m)))
                .Should().BeEmpty();
        }
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainEvent_ShouldHave_DomainEventPostfix(string module)
    {
        foreach (var assemblyName in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InAssembly(Assembly.Load(assemblyName))
                .That()
                .Inherit(typeof(DomainEvent))
                .Should().HaveNameEndingWith("DomainEvent")
                .GetResult().FailingTypes
                .Should().BeNullOrEmpty();
        }
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainModel_ShouldNotHave_NestedTypes(string module)
    {
        foreach (var assemblyName in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InAssembly(Assembly.Load(assemblyName))
                .ShouldNot().BeNested()
                .GetResult().FailingTypes
                .Should().BeNullOrEmpty();
        }
    }
}