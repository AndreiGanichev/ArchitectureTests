using MediatR;
using ToDoList.Tasks.Application.Internals.Interfaces;

namespace ToDoList.Tasks.Infrastructure.MessageBus;

public class MessageBus : IMessageBus
{
    private readonly IMediator _mediator;

    public MessageBus(IMediator mediator)
    {
        _mediator = mediator;
    }

    public Task Publish<T>(T message, CancellationToken cancellationToken) where T : INotification =>
        _mediator.Publish(message, cancellationToken);
}