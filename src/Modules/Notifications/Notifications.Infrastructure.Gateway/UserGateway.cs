using ToDoList.Notifications.Application.Internals.Interfaces;
using ToDoList.Notifications.Domain;

namespace ToDoList.Notifications.Infrastructure.Gateway;

public class UserGateway : IAddresseRepository
{
    private readonly Dictionary<Guid, Addressee> _addressees = new()
    {
        {
            new Guid("00000000-0000-0000-0000-000000000001"),
            Addressee.Create(
                Name.Create("Ivan"),
                PhoneNumber.Create("+71111111111"))
        }
    };

    public Addressee? Get(Guid id) => _addressees.TryGetValue(id, out var value) ? value : null;
}