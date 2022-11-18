using MediatR;
using ToDoList.Notifications.Application.Contracts;
using ToDoList.Tasks.Application.Contracts;

namespace ToDoList.Notifications.Infrastructure.MessageBus;

public class TaskCreatedIntegrationEventHandler : INotificationHandler<TaskCreatedIntegrationEvent>
{
    private readonly IMediator _mediator;

    public TaskCreatedIntegrationEventHandler(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Handle(TaskCreatedIntegrationEvent notification, CancellationToken cancellationToken)
    {
        var command = new AddNotificationCommand(notification.TaskId, notification.AuthorId, notification.Title,
            notification.RemindAt);

        await _mediator.Send(command, cancellationToken);
    }
}