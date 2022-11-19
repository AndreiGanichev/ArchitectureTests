using ToDoList.BuildingBlocks.Domain;
using ToDoList.Tasks.Domain.Exceptions;

namespace ToDoList.Tasks.Domain;

public class Title : ValueObject
{
    private const int TitleLengthLimit = 300;
    
    private readonly string _value;

    private Title(string value)
    {
        if (value.Length > TitleLengthLimit)
        {
            throw new TitleIsTooLongException();
        }
        
        _value = value;
    }

    public static Title Create(string title) => new(title);

    public override string ToString() => _value;
}