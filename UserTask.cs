namespace TaskListApp.Models;

public class UserTask
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
}
