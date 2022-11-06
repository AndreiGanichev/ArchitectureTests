using MediatR;
using ToDoList.Tasks.Application.Contracts;

namespace ToDoList.Tasks.Application.Internals;

internal sealed class AddTaskHandler : IRequestHandler<AddTaskCommand>
{
    public Task<Unit> Handle(AddTaskCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}