using ToDoList.BuildingBlocks;

namespace ToDoList.Notifications.Domain;

public class Body : ValueObject
{
    private readonly string _value;

    private Body(string value)
    {
        _value = value;
    }

    public static Body Create(string value) => new Body(value);
}