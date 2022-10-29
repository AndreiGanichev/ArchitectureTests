using MediatR;

namespace ToDoList.Tasks.Application.Contracts;

public class AddTaskCommand : IRequest
{
    public AddTaskCommand(string title)
    {
        Title = title;
    }

    public string Title { get; }
}