using System;
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
            "ToDoList.Tasks",
            new[]
            {
                "ToDoList.Tasks.Domain",
                "ToDoList.Tasks.Application.Internals",
                "ToDoList.Tasks.Application.Contracts",
                "ToDoList.Tasks.Infrastructure.Configuration",
                "ToDoList.Tasks.Application.Database",
                "ToDoList.Tasks.Application.MessageBus"
            }
        },
        {
            "ToDoList.Notifications",
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
        var pattern = $"{module}.Domain*";
        return Modules[module].Where(ns => Regex.IsMatch(ns, pattern)).ToArray();
    }

    #endregion

    #region Application

    public string[] ApplicationOf(string module) =>
        Modules[module].Where(ns => Regex.IsMatch(ns, $"{module}.Application*")).ToArray();
    
    public string ApplicationInternalsOf(string module) =>
        Modules.SelectMany(m => m.Value).Single(ns => string.Equals(ns, $"{module}.Application.Internals", StringComparison.OrdinalIgnoreCase));
    
    public string ApplicationContractsOf(string module) =>
        Modules.SelectMany(m => m.Value).Single(ns => string.Equals(ns, $"{module}.Application.Contracts", StringComparison.OrdinalIgnoreCase));

    #endregion

    #region Infrastructure

    public string[] InfrastructureOf(string module) =>
        Modules[module].Where(ns => Regex.IsMatch(ns, $"{module}.Infrastructure*")).ToArray();
    
    public string? InfrastructureModulesOf(string module) =>
        Modules.SelectMany(m => m.Value).SingleOrDefault(ns => string.Equals(ns, $"{module}.Infrastructure.Modules", StringComparison.OrdinalIgnoreCase));

    #endregion

    public string[] Except(string exceptionModule) =>
        Modules.Where(m => m.Key != exceptionModule).SelectMany(m => m.Value).Except(new[] {exceptionModule}).ToArray();

    #region IEnumerable

    IEnumerator<string> IEnumerable<string>.GetEnumerator() =>
        Modules.Select(m => m.Key).GetEnumerator();

    public IEnumerator<object[]> GetEnumerator() => 
        Modules.Select(m => new[]{m.Key}).GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}