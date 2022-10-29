using System.Collections.Generic;
using System.Reflection;
using ToDoList.Api;

namespace ToDoList.ArchitectureTests.Architecture;

public static class Architecture
{
    public static readonly Assembly ApiAssembly = typeof(Startup).Assembly;

    public static Dictionary<Modules, string> ModuleNamespaces = new()
    {
        {Modules.Tasks, "ToDoList.Modules.Tasks"},
        {Modules.Notifications, "ToDoList.Modules.Notifications"}
    };
}