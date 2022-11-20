using MediatR;

namespace ToDoList.Tasks.Application.Internals.Interfaces;

public interface IMessageBus
{
    public Task Publish<T>(T message, CancellationToken cancellationToken) where T : INotification;
}