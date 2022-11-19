using ArchUnitNET.Domain;
using ArchUnitNET.Loader;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using static ArchUnitNET.Fluent.ArchRuleDefinition;

namespace ToDoList.ArchitectureTests.Explorers;

public static class ArchitectureExplorer
{
    public static ModuleList Modules { get; } = new();

    public static IObjectProvider<IType> DomainLayerOf(string module) =>
        Types()
            .That().ResideInNamespace($"{module}.Domain", true);

    public static IObjectProvider<IType> ApplicationLayerOf(string module) =>
        Types()
            .That().ResideInNamespace($"{module}.Application.*", true);

    public static IObjectProvider<IType> InfrastructureLayerOf(string module) =>
        Types()
            .That().ResideInNamespace($"{module}.Infrastructure.*", true);

    public static IObjectProvider<IType> PresentationLayer =>
        Types()
            .That().ResideInNamespace("ToDoList.Api", true);

    private static IObjectProvider<IType> ModulePublicInterface(string module) =>
        Types()
            .That().ResideInNamespace($"{module}.Application.Contracts*", true)
            .Or().ResideInAssembly($"{module}.Infrastructure.Configuration*", true);


    #region Domain layer

    public static IObjectProvider<IType> DomainLayers =>
        Types()
            .That().ResideInNamespace("ToDoList.*.Domain", true);

    #endregion

    #region Application layer

    public static IObjectProvider<IType> ApplicationContracts =>
        Types()
            .That().ResideInNamespace("ToDoList.*.Application.Contracts", true);

    public static IObjectProvider<IType> ApplicationInternals =>
        Types()
            .That().ResideInNamespace("ToDoList.*.Application.Internals", true);

    #endregion

    #region Infrastructure layer

    public static IObjectProvider<IType> InfrastructureGatewayOrMessageBusOf(string module) =>
        Types()
            .That().ResideInNamespace($"{module}.Infrastructure.Gateway", true)
            .Or().ResideInNamespace($"{module}.Infrastructure.MessageBus", true);

    #endregion

    #region Module

    public static IObjectProvider<IType> ModuleExceptPublicInterface(string module) =>
        Types()
            .That().ResideInNamespace($"{module}*", true)
            .And().AreNot(ModulePublicInterface(module));

    #endregion

    public static readonly Architecture ToDoListArchitecture = new ArchLoader().LoadAssemblies(
            // Notifications module
            System.Reflection.Assembly.Load("ToDoList.Notifications.Domain"),
            System.Reflection.Assembly.Load("ToDoList.Notifications.Application.Internals"),
            System.Reflection.Assembly.Load("ToDoList.Notifications.Application.Contracts"),
            System.Reflection.Assembly.Load("ToDoList.Notifications.Infrastructure.Configuration"),
            System.Reflection.Assembly.Load("ToDoList.Notifications.Infrastructure.Database"),
            System.Reflection.Assembly.Load("ToDoList.Notifications.Infrastructure.MessageBus"),
            System.Reflection.Assembly.Load("ToDoList.Notifications.Infrastructure.Gateway"),
            // Tasks module
            System.Reflection.Assembly.Load("ToDoList.Tasks.Domain"),
            System.Reflection.Assembly.Load("ToDoList.Tasks.Application.Internals"),
            System.Reflection.Assembly.Load("ToDoList.Tasks.Application.Contracts"),
            System.Reflection.Assembly.Load("ToDoList.Tasks.Infrastructure.Configuration"),
            System.Reflection.Assembly.Load("ToDoList.Tasks.Infrastructure.Database"),
            System.Reflection.Assembly.Load("ToDoList.Tasks.Infrastructure.MessageBus"),
            // Api
            System.Reflection.Assembly.Load("ToDoList.Api"),
            typeof(AuthorizeAttribute).Assembly,
            typeof(HttpMethodAttribute).Assembly,
            typeof(IActionResult).Assembly)
        .Build();
}