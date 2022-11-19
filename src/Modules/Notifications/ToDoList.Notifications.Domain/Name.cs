namespace ToDoList.Notifications.Domain;

public class Name
{
    private readonly string _value;

    private Name(string value)
    {
        _value = value;
    }

    public static Name Create(string name) => new(name);
}