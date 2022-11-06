using ToDoList.BuildingBlocks;

namespace ToDoList.Tasks.Domain;

public class Supervisor : Entity
{
    public string Name { get; }

    private Supervisor(string name)
    {
        Name = name;
    }

  internal static Supervisor Create(string name) => new Supervisor(name);
}