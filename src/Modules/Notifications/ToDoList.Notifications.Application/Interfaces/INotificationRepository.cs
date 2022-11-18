namespace ToDoList.Notifications.Application.Internals.Interfaces;

public interface INotificationRepository
{
    public Domain.Notification? Get(Guid id);
    public void Add(Domain.Notification notification);
}