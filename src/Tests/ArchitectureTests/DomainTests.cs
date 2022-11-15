using System.Linq;
using ArchUnitNET.Domain;
using ArchUnitNET.Domain.Extensions;
using ArchUnitNET.xUnit;
using FluentAssertions;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ToDoList.ArchitectureTests.Explorers.ArchitectureExplorer;
using static ToDoList.ArchitectureTests.Explorers.DomainModelExplorer;

namespace ToDoList.ArchitectureTests;

public class DomainTests
{
    [Fact]
    public void DomainEvent_ShouldBe_Immutable()
    {
        // immutability check implemented but not released yet
    }

    [Fact]
    public void ValueObject_ShouldBe_Immutable()
    {
        // immutability check implemented but not released yet
    }

    [Fact]
    public void Entity_ShouldNotHave_PublicSetters()
    {
        Types()
            .That().Are(Entities)
            .GetObjects(ToDoListArchitecture)
            .Where(t =>
            {
                var e = t.GetMethodMembers()
                    .Any(m => m.MethodForm == MethodForm.Setter 
                              && m.Visibility == Visibility.Public);
                return e;
            })
            .Should().BeEmpty();
    }
    
    [Fact]
    public void Entity_WhichIsNotAggregateRoot_ShouldNotHave_PublicMethods()
    {
        Types()
            .That().Are(Entities)
            .And().AreNot(AggregateRoots)
            .GetObjects(ToDoListArchitecture)
            .Where(t => 
                t.GetMethodMembers()
                    .Any(m => 
                        m.MethodForm is not (MethodForm.Getter or MethodForm.Setter)
                        && m.Visibility == Visibility.Public))
            .Should().BeEmpty();
    }

    [Fact]
    public void DomainModel_ShouldNotHave_NestedTypes()
    {
        Types()
            .That().Are(DomainLayers)
            .Should().NotBeNested()
            .Check(ToDoListArchitecture);
    }
}