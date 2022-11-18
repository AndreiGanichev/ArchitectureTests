using MediatR;
using MediatR.Registration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Notifications.Application.Internals.Interfaces;
using ToDoList.Notifications.Infrastructure.Database;

namespace ToDoList.Notifications.Infrastructure.Configuration;

public static class NotificationModule
{
    public static void Configure(IServiceCollection services, MediatRServiceConfiguration mediatrConfig)
    {
        ServiceRegistrar.AddMediatRClasses(services, new[] {typeof(INotificationRepository).Assembly}, mediatrConfig);
        services.AddScoped<INotificationRepository, NotificationRepository>();
    }
}