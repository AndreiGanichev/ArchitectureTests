using ArchUnitNET.Domain;
using ToDoList.BuildingBlocks;
using static ArchUnitNET.Fluent.ArchRuleDefinition;
using static ToDoList.ArchitectureTests.ArchitectureExplorer;

namespace ToDoList.ArchitectureTests;

internal static class DomainModelExplorer
{
    public static readonly IObjectProvider<Class> DomainEvents =
        Classes().That()
            .Are(DomainLayers)
            .And()
            .AreAssignableTo(typeof(DomainEvent));

    public static readonly IObjectProvider<Class> ValueObjects =
        Classes().That()
            .Are(DomainLayers)
            .And()
            .AreAssignableTo(typeof(ValueObject));

    public static readonly IObjectProvider<Class> Entities =
        Classes().That()
            .Are(DomainLayers)
            .And()
            .AreAssignableTo(typeof(Entity));

    public static readonly IObjectProvider<Class> AggregateRoots =
        Classes().That()
            .Are(DomainLayers)
            .And()
            .ImplementInterface(typeof(IAggregateRoot));
}