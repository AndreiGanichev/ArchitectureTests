using ToDoList.Notifications.Domain;

namespace ToDoList.Notifications.Application.Internals.Interfaces;

public interface IAddresseRepository
{
    Addressee? Get(Guid id);
}