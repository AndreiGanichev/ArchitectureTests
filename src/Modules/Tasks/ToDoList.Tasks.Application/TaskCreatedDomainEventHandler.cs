using MediatR;
using ToDoList.Tasks.Application.Contracts;
using ToDoList.Tasks.Domain.Events;

namespace ToDoList.Tasks.Application.Internals;

internal sealed class TaskCreatedDomainEventHandler : INotificationHandler<TaskCreatedDomainEvent>
{
    private readonly IMediator _mediator;

    public TaskCreatedDomainEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(TaskCreatedDomainEvent notification, CancellationToken cancellationToken)
    {
        await _mediator.Publish(new TaskCreatedIntegrationEvent(
            notification.TaskId,
            notification.AuthorId,
            notification.Title.ToString(),
            notification.Date,
            notification.RemindAt),
            cancellationToken);
    }
}