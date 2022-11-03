using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ToDoList.ArchUnitNET;

public static class ArchitectureExplorer
{
    public static ModuleList Modules { get; } = new();

    public static readonly Architecture ToDoListArchitecture = new ArchLoader().LoadAssemblies(
            // Notifications module
            System.Reflection.Assembly.Load("ToDoList.Notifications.Domain"),
            System.Reflection.Assembly.Load("ToDoList.Notifications.Application.Internals"),
            System.Reflection.Assembly.Load("ToDoList.Notifications.Application.Contracts"),
            System.Reflection.Assembly.Load("ToDoList.Notifications.Infrastructure.Configuration"),
            System.Reflection.Assembly.Load("ToDoList.Notifications.Infrastructure.Database"),
            System.Reflection.Assembly.Load("ToDoList.Notifications.Infrastructure.MessageBus"),
            System.Reflection.Assembly.Load("ToDoList.Notifications.Infrastructure.Modules"),
            System.Reflection.Assembly.Load("ToDoList.Notifications.Infrastructure.Telegram"),
            // Tasks module
            System.Reflection.Assembly.Load("ToDoList.Tasks.Domain"),
            System.Reflection.Assembly.Load("ToDoList.Tasks.Application.Internals"),
            System.Reflection.Assembly.Load("ToDoList.Tasks.Application.Contracts"),
            System.Reflection.Assembly.Load("ToDoList.Tasks.Infrastructure.Configuration"),
            System.Reflection.Assembly.Load("ToDoList.Tasks.Infrastructure.Database"),
            System.Reflection.Assembly.Load("ToDoList.Tasks.Infrastructure.MessageBus"))
        .Build();

    #region Domain layer

    public static IObjectProvider<IType> DomainLayers =>
        Types()
            .That().ResideInNamespace("ToDoList.*.Domain", true);
    
    public static IObjectProvider<IType> DomainLayerOf(string module) =>
        Types()
            .That().ResideInNamespace($"{module}.Domain", true);

    #endregion

    #region Application layer

    public static IObjectProvider<IType> ApplicationLayerOf(string module) =>
        Types()
            .That().ResideInNamespace($"{module}.Application.*", true);
    
    public static IObjectProvider<IType> ApplicationContracts =>
        Types()
            .That().ResideInNamespace("ToDoList.*.Application.Contracts", true);
    
    public static IObjectProvider<IType> ApplicationInternals =>
        Types()
            .That().ResideInNamespace("ToDoList.*.Application.Internals", true);
    
    public static IObjectProvider<IType> ApplicationContractsOrExclusions =>
        Types()
            .That().ResideInNamespace("ToDoList.*.Application.Contracts", true)
            .Or()
            .Are(Exclusions);

    #endregion

    #region Infrastructure layer

    public static IObjectProvider<IType> InfrastructureLayerOf(string module) =>
        Types()
            .That().ResideInNamespace($"{module}.Infrastructure.*", true);

    public static IObjectProvider<IType> InfrastructureModulesOf(string module) =>
        Types()
            .That().ResideInNamespace($"{module}.Infrastructure.Modules", true);
    
    #endregion

    #region Presentation layer

    public static IObjectProvider<IType> PresentationLayer =>
        Types()
            .That().ResideInNamespace("ToDoList.Api", true);

    #endregion

    private static IObjectProvider<IType> Exclusions =>
        Types().That().DoNotResideInNamespace("ToDoList.*", true);
}