namespace ToDoList.Api.Tasks;

[Serializable]
public class AddTaskRequest
{
    public Guid UserId { get; set; }
    public string Title { get; set; } = string.Empty;
    public DateOnly Date { get; set; }
    public DateTimeOffset RemindAt { get; set; }
}