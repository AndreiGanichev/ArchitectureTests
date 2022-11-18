using MediatR;
using ToDoList.BuildingBlocks.Application;
using ToDoList.Notifications.Application.Contracts;
using ToDoList.Notifications.Application.Internals.Interfaces;
using ToDoList.Notifications.Domain;

namespace ToDoList.Notifications.Application.Internals;

internal sealed class AddNotificationHandler : IRequestHandler<AddNotificationCommand>
{
    private readonly INotificationRepository _notifications;
    private readonly IAddresseRepository _addresses;

    public AddNotificationHandler(INotificationRepository notifications, IAddresseRepository addresses)
    {
        _notifications = notifications;
        _addresses = addresses;
    }

    public Task<Unit> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
    {
        var addressee = _addresses.Get(request.Id)
                        ?? throw new InvalidCommandException();
        
        var notification = Notification.Create(
            request.Id,
            addressee,
            Body.Create(request.Body),
            request.Channel,
            request.At);

        _notifications.Add(notification);

        return Unit.Task;
    }
}