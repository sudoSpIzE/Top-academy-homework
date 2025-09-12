using Microsoft.AspNetCore.Mvc;
using TimeGreetingApp.Services;

namespace TimeGreetingApp.Controllers;

public class HomeController : Controller
{
    private readonly IGreetingService _greetingService;

    public HomeController(IGreetingService greetingService)
    {
        _greetingService = greetingService;
    }

    public string Index()
    {
        return "Hello, world!";
    }

    [HttpGet]
    public string Welcome()
    {
        return _greetingService.GetWelcomeMessage();
    }

    [HttpGet]
    public string Time()
    {
        return DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
    }
}