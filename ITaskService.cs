using TaskListApp.Models;

namespace TaskListApp.Services;

public interface ITaskService
{
    List<UserTask> GetAllTasks();
}
