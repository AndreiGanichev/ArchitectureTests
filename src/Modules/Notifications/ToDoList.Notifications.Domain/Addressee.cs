using ToDoList.BuildingBlocks.Domain;

namespace ToDoList.Notifications.Domain;

public class Addressee : ValueObject
{
    public Name Name { get; }
    public PhoneNumber PhoneNumber { get; }

    private Addressee(Name name, PhoneNumber phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }

    public static Addressee Create(Name name, PhoneNumber phoneNumber) => new(name, phoneNumber);
}