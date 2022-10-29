using MediatR;
using ToDoList.Tasks.Application.Contracts;

namespace ToDoList.Tasks.Application.Internals;

public class AddTaskHandler : IRequestHandler<AddTaskCommand>
{
    public Task<Unit> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}