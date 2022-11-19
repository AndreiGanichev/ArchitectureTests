using ToDoList.Notifications.Application.Internals.Interfaces;
using ToDoList.Notifications.Domain;

namespace ToDoList.Notifications.Infrastructure.Database;

public class NotificationRepository : INotificationRepository
{
    private readonly Dictionary<Guid, Notification> _notifications = new();

    public Notification? Get(Guid id) => _notifications.TryGetValue(id, out var value) ? value : null;

    public void Add(Notification notification)
    {
        _notifications.Add(notification.Id, notification);
        
        var domainEvents = notification.DomainEvents;
        //ToDo: publish domain events
    }
}