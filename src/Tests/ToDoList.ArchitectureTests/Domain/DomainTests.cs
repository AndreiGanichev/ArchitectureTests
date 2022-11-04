using System.Linq;
using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;
using ToDoList.BuildingBlocks;
using Xunit;

namespace ToDoList.NetArchTest.Domain;

public class DomainTests
{
    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainEvent_Should_Be_Immutable(string module)
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
    public void ValueObject_Should_Be_Immutable(string module)
    {
        foreach (var domain in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InNamespace(domain)
                .That()
                .Inherit(typeof(ValueObject))
                .ShouldNot().BeMutable()
                .GetResult().FailingTypes
                .Should().BeNullOrEmpty();
        }
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void Entity_Which_Is_Not_Aggregate_Root_Cannot_Have_Public_Methods(string module)
    {
        const BindingFlags bindingFlags = BindingFlags.Public |
                                          BindingFlags.Instance |
                                          BindingFlags.Static;

        foreach (var domain in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InNamespace(domain)
                .That()
                .Inherit(typeof(Entity))
                .And().DoNotImplementInterface(typeof(IAggregateRoot))
                .GetTypes()
                .Where(t => t.GetMethods(bindingFlags).Any()).Should().BeEmpty();
        }
    }

    [Theory]
    [ClassData(typeof(ModuleList))]
    public void DomainEvent_Should_Have_DomainEventPostfix(string module)
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
    public void DomainModel_Should_Not_Have_NestedTypes(string module)
    {
        foreach (var domain in ArchitectureExplorer.Modules.DomainOf(module))
        {
            Types.InNamespace(domain)
                .ShouldNot().BeNested()
                .GetResult().FailingTypes
                .Should().BeNullOrEmpty();
        }
    }
}