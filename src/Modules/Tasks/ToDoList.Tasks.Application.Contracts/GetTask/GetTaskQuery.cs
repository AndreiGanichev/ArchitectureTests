using MediatR;
using ToDoList.Tasks.Application.Contracts.GetTask;

namespace ToDoList.Tasks.Application.Contracts;

public class GetTaskQuery : IRequest<TaskDto?>
{
    public Guid TaskId { get; }
    
    public GetTaskQuery(Guid taskId)
    {
        TaskId = taskId;
    }
}