using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ToDoList.NetArchTest;

public class ModuleList : IEnumerable<object[]>, IEnumerable<string>
{
    private static readonly Dictionary<string, string[]> Modules = new()
    {
        {
            "Tasks",
            new[]
            {
                "ToDoList.Task.Domain",
                "ToDoList.Task.Application.Internals",
                "ToDoList.Task.Application.Contracts",
                "ToDoList.Task.Infrastructure.Configuration",
                "ToDoList.Task.Application.Database",
                "ToDoList.Task.Application.MessageBus"
            }
        },
        {
            "Notifications",
            new[]
            {
                "ToDoList.Notifications.Domain",
                "ToDoList.Notifications.Application.Internals",
                "ToDoList.Notifications.Application.Contracts",
                "ToDoList.Notifications.Infrastructure.Configuration",
                "ToDoList.Notifications.Infrastructure.Database",
                "ToDoList.Notifications.Infrastructure.MessageBus",
                "ToDoList.Notifications.Infrastructure.Modules",
                "ToDoList.Notifications.Infrastructure.Telegram"
            }
        }
    };

    #region Domain

    public string[] DomainOf(string module)
    {
        var pattern = $"ToDoList.{module}.Domain*";
        return Modules[module].Where(ns => Regex.IsMatch(ns, pattern)).ToArray();
    }

    #endregion

    #region Application

    public string[] ApplicationOf(string module) =>
        Modules[module].Where(ns => Regex.IsMatch(ns, $"ToDoList.{module}.Application*")).ToArray();
    
    public string ApplicationInternalsOf(string module) =>
        Modules.SelectMany(m => m.Value).Single(ns => Regex.IsMatch(ns, $"ToDoList.{module}.Application.Internals"));
    
    public string ApplicationContractsOf(string module) =>
        Modules.SelectMany(m => m.Value).Single(ns => Regex.IsMatch(ns, $"ToDoList.{module}.Application.Contracts"));

    #endregion

    #region Infrastructure

    public string[] InfrastructureOf(string module) =>
        Modules[module].Where(ns => Regex.IsMatch(ns, $"ToDoList.{module}.Infrastructure*")).ToArray();
    
    public string InfrastructureModulesOf(string module) =>
        Modules.SelectMany(m => m.Value).Single(ns => Regex.IsMatch(ns, $"ToDoList.{module}.Infrastructure.Contracts"));

    #endregion

    public string[] Except(string exceptionModule) =>
        Modules.Where(m => m.Key != exceptionModule).SelectMany(m => m.Value).Except(new[] {exceptionModule}).ToArray();

    #region IEnumerable

    IEnumerator<string> IEnumerable<string>.GetEnumerator() =>
        Modules.Select(m => $"ToDoList.{m.Key}").GetEnumerator();

    public IEnumerator<object[]> GetEnumerator() => 
        Modules.Select(m => new[]{$"ToDoList.{m.Key}"}).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}