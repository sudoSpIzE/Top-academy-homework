using TaskListApp.Models;

namespace TaskListApp.Services;

public class TaskService : ITaskService
{
    private readonly List<UserTask> _tasks = new();

    public TaskService()
    {
        // Пример начальных данных
        _tasks.Add(new UserTask 
        { 
            Title = "Изучить ASP.NET Core", 
            Description = "Освоить основы Razor Pages" 
        });
    }

    public List<UserTask> GetAllTasks() => _tasks;
}
