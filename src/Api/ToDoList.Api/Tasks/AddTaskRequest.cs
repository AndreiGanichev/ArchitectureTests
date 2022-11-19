namespace ToDoList.Api.Tasks;

[Serializable]
public class AddTaskRequest
{
    public string Title { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public DateTimeOffset RemindAt { get; set; }
}