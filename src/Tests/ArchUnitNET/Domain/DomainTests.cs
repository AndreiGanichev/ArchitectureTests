using System.Linq;
using ArchUnitNET.Domain;
using ArchUnitNET.Domain.Extensions;
using ArchUnitNET.xUnit;
using FluentAssertions;
using ToDoList.BuildingBlocks;
using Xunit;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ToDoList.ArchUnitNET.ArchitectureExplorer;

namespace ToDoList.ArchUnitNET.Domain;

public class DomainTests
{
    private static readonly IObjectProvider<Class> DomainModel =
        Classes().That()
            .ResideInNamespace("ToDoList.*.Domain", useRegularExpressions: true);

    private static readonly IObjectProvider<Class> DomainEvents =
        Classes().That()
            .ResideInNamespace("ToDoList.*.Domain", useRegularExpressions: true)
            .And()
            .AreAssignableTo(typeof(DomainEvent));

    private static readonly IObjectProvider<Class> ValueObjects =
        Classes().That()
            .ResideInNamespace("ToDoList.*.Domain", useRegularExpressions: true)
            .And()
            .AreAssignableTo(typeof(ValueObject));

    private static readonly IObjectProvider<Class> Entities =
        Classes().That()
            .ResideInNamespace("ToDoList.*.Domain", useRegularExpressions: true)
            .And()
            .AreAssignableTo(typeof(Entity));

    private static readonly IObjectProvider<Class> AggregateRoots =
        Classes().That()
            .ResideInNamespace("ToDoList.*.Domain", useRegularExpressions: true)
            .And()
            .ImplementInterface(typeof(IAggregateRoot));

    [Fact]
    public void DomainEvent_Should_Be_Immutable()
    {
        // immutability check implemented but not released yet
    }

    [Fact]
    public void ValueObject_Should_Be_Immutable()
    {
        // immutability check implemented but not released yet
    }

    [Fact]
    public void Entities_Cannot_Have_Public_Setters()
    {
        Types()
            .That().Are(Entities)
            .GetObjects(ToDoListArchitecture)
            .Where(t =>
            {
                var e = t.GetMethodMembers().Any(m => m.MethodForm == MethodForm.Setter && m.Visibility == Visibility.Public);
                return e;
            })
            .Should().BeEmpty();
    }
    
    [Fact]
    public void Entity_Which_Is_Not_Aggregate_Root_Cannot_Have_Public_Methods()
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
    public void DomainEvent_Should_Have_DomainEventPostfix()
    {
        Types().That().Are(DomainEvents)
            .Should().HaveNameEndingWith("DomainEvent")
            .Check(ToDoListArchitecture);
    }

    [Fact]
    public void DomainModel_Should_Not_Have_NestedTypes()
    {
        Types()
            .That().Are(DomainModel)
            .Should().NotBeNested()
            .Check(ToDoListArchitecture);
    }
}