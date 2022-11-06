using MediatR;
using ToDoList.Notifications.Application.Contracts;

namespace ToDoList.Notifications.Application.Internals;

internal sealed class AddNotificationHandler : IRequestHandler<AddNotificationCommand>
{
    public Task<Unit> Handle(AddNotificationCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}