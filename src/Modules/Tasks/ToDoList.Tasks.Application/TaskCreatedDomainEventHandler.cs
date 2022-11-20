using MediatR;
using ToDoList.Tasks.Application.Contracts;
using ToDoList.Tasks.Application.Internals.Interfaces;
using ToDoList.Tasks.Domain.Events;

namespace ToDoList.Tasks.Application.Internals;

internal sealed class TaskCreatedDomainEventHandler : INotificationHandler<TaskCreatedDomainEvent>
{
    private readonly IMessageBus _messageBus;

    public TaskCreatedDomainEventHandler(IMessageBus messageBus)
    {
        _messageBus = messageBus;
    }

    public async Task Handle(TaskCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _messageBus.Publish(new TaskCreatedIntegrationEvent(
            notification.TaskId,
            notification.AuthorId,
            notification.Title.ToString(),
            notification.Date,
            notification.RemindAt),
            cancellationToken);
    }
}