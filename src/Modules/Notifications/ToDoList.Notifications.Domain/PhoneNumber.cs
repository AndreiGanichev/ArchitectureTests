using ToDoList.BuildingBlocks;

namespace ToDoList.Notifications.Domain;

public class PhoneNumber : ValueObject
{
    public string _countryCode { get; }
    public string _number { get; }

    private PhoneNumber(string value)
    {
        //ToDo: extract code and number
    }

    public static PhoneNumber Create(string value) => new PhoneNumber(value);
}