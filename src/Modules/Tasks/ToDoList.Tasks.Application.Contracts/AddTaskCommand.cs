using MediatR;

namespace ToDoList.Tasks.Application.Contracts;

public class AddTaskCommand : IRequest<Guid>
{
    public Guid UserId { get; }
    public string Title { get; }

    public AddTaskCommand(Guid userId, string title)
    {
        Title = title;
        UserId = userId;
    }
}