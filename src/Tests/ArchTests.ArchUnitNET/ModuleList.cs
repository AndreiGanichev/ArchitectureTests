using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ArchTests.ArchUnitNET;

public class ModuleList : IEnumerable<object[]>
{
    private readonly IEnumerable<string[]> _modules = new[]
    {
        new[] {"ToDoList.Tasks"},
        new[] {"ToDoList.Notifications"},
    };

    public string[] Except(string exceptionModule) =>
        _modules.SelectMany(m => m).Except(new[] {exceptionModule}).ToArray();

    #region IEnumerable

    public IEnumerator<object[]> GetEnumerator() => _modules.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    #endregion
}