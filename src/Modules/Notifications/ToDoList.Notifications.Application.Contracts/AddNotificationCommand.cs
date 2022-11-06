using MediatR;

namespace ToDoList.Notifications.Application.Contracts;

public class AddNotificationCommand : IRequest
{
    public string Title { get; }
}