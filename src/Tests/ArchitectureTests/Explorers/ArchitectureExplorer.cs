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
            // Tasks module
            typeof(Tasks.Domain.Task).Assembly,
            typeof(Tasks.Application.Contracts.AddTask.AddTaskCommand).Assembly,
            typeof(Tasks.Application.Internals.Interfaces.ITaskRepository).Assembly,
            typeof(Tasks.Infrastructure.Configuration.TaskModule).Assembly,
            typeof(Tasks.Infrastructure.Database.TaskRepository).Assembly,
            // Notifications module
            typeof(Notifications.Domain.Notification).Assembly,
            typeof(Notifications.Application.Contracts.AddNotificationCommand).Assembly,
            typeof(Notifications.Application.Internals.Interfaces.IAddresseRepository).Assembly,
            typeof(Notifications.Infrastructure.Configuration.NotificationModule).Assembly,
            typeof(Notifications.Infrastructure.Database.NotificationRepository).Assembly,
            typeof(Notifications.Infrastructure.MessageBus.TaskCreatedIntegrationEventHandler).Assembly,
            typeof(Notifications.Infrastructure.Gateway.UserGateway).Assembly,
            // Api
            typeof(Api.Tasks.TasksController).Assembly)
        .Build();
}