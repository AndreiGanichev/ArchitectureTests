using MediatR;

namespace ToDoList.Tasks.Application.Contracts.GetTask;

public class GetTaskQuery : IRequest<TaskDto?>
{
    public Guid TaskId { get; }
    
    public GetTaskQuery(Guid taskId)
    {
        TaskId = taskId;
    }
}