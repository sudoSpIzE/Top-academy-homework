using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskListApp.Services;
using TaskListApp.Models;

namespace TaskListApp.Pages;

public class TaskListModel : PageModel
{
    private readonly ITaskService _taskService;

    public TaskListModel(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public List<UserTask> Tasks { get; set; } = new();

    public void OnGet()
    {
        Tasks = _taskService.GetAllTasks();
    }
}
