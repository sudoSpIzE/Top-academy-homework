using Microsoft.AspNetCore.Mvc;

namespace TimeGreetingApp.Controllers;

public class HomeController : Controller
{
    public string Index()
    {
        return "Hello, world!";
    }
}
