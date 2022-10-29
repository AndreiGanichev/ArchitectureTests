using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using NetArchTest.Rules;
using ToDoList.BuildingBlocks;
using Xunit;

namespace ToDoList.ArchitectureTests.Domain;

public class DomainTests
{
    [Fact]
    public void DomainEvent_Should_Be_Immutable()
    {
        Types.InAssemblies(new[]
            {
                Assembly.Load("ToDoList.Tasks.Domain"),
                Assembly.Load("ToDoList.Notifications.Domain")
            })
            .That()
            .Inherit(typeof(DomainEvent))
            .ShouldNot().BeMutable()
            .GetResult().FailingTypes
            .Should().BeNullOrEmpty();
    }

    [Fact]
    public void ValueObject_Should_Be_Immutable()
    {
        Types.InAssemblies(new[]
            {
                Assembly.Load("ToDoList.Tasks.Domain"),
                Assembly.Load("ToDoList.Notifications.Domain")
            })
            .That()
            .Inherit(typeof(ValueObject))
            .ShouldNot().BeMutable()
            .GetResult().FailingTypes
            .Should().BeNullOrEmpty();
    }

    [Fact]
    public void Entity_Which_Is_Not_Aggregate_Root_Cannot_Have_Public_Members()
    {
        var types = Types.InAssemblies(new[]
            {
                Assembly.Load("ToDoList.Tasks.Domain"),
                Assembly.Load("ToDoList.Notifications.Domain")
            })
            .That()
            .Inherit(typeof(Entity))
            .And().DoNotImplementInterface(typeof(IAggregateRoot)).GetTypes();

        const BindingFlags bindingFlags = BindingFlags.DeclaredOnly |
                                          BindingFlags.Public |
                                          BindingFlags.Instance |
                                          BindingFlags.Static;

        var failingTypes = new List<Type>();
        foreach (var type in types)
        {
            var publicFields = type.GetFields(bindingFlags);
            var publicProperties = type.GetProperties(bindingFlags);
            var publicMethods = type.GetMethods(bindingFlags);

            if (publicFields.Any() || publicProperties.Any() || publicMethods.Any())
            {
                failingTypes.Add(type);
            }
        }

        failingTypes.Should().BeEmpty();
    }

    [Fact]
    public void DomainEvent_Should_Have_DomainEventPostfix()
    {
        Types.InAssemblies(new[]
            {
                Assembly.Load("ToDoList.Tasks.Domain"),
                Assembly.Load("ToDoList.Notifications.Domain")
            })
            .That()
            .Inherit(typeof(DomainEvent))
            .Should().HaveNameEndingWith("Event")
            .GetResult().FailingTypes
            .Should().BeNullOrEmpty();
    }
}