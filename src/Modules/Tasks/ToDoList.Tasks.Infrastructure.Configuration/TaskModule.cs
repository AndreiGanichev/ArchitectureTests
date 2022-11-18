using MediatR;
using MediatR.Registration;
using Microsoft.Extensions.DependencyInjection;
using ToDoList.Tasks.Application.Internals.Interfaces;
using ToDoList.Tasks.Infrastructure.Database;

namespace ToDoList.Tasks.Infrastructure.Configuration;

public static class TaskModule
{
    public static void Configure(IServiceCollection services, MediatRServiceConfiguration mediatrConfig)
    {
        ServiceRegistrar.AddMediatRClasses(services, new[] {typeof(ITaskRepository).Assembly}, mediatrConfig);
        services.AddScoped<ITaskRepository, TaskRepository>();
    }
}