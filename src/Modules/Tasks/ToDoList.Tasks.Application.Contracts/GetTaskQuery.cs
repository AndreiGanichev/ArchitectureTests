using MediatR;

namespace ToDoList.Tasks.Application.Contracts;

public class GetTaskQuery : IRequest<Domain.Task>
{
    public Guid TaskId { get; }
    
    public GetTaskQuery(Guid taskId)
    {
        TaskId = taskId;
    }
}