using MediatR;
using MediatR.Registration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Notifications.Application.Internals.Interfaces;
using ToDoList.Notifications.Infrastructure.Database;
using ToDoList.Notifications.Infrastructure.Gateway;

namespace ToDoList.Notifications.Infrastructure.Configuration;

public static class NotificationModule
{
    public static void Configure(IServiceCollection services, MediatRServiceConfiguration mediatrConfig)
    {
        ServiceRegistrar.AddMediatRClasses(services, new[] {typeof(INotificationRepository).Assembly}, mediatrConfig);
        services.AddSingleton<INotificationRepository, NotificationRepository>();
        services.AddSingleton<IAddresseRepository, UserGateway>();
    }
}