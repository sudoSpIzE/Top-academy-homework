namespace TimeGreetingApp.Services;

public interface IGreetingService
{
    string GetWelcomeMessage();
}

public class GreetingService : IGreetingService
{
    public string GetWelcomeMessage()
    {
        var hour = DateTime.Now.Hour;
        
        return hour switch
        {
            >= 5 and < 12 => "Доброе утро!",
            >= 12 and < 17 => "Добрый день!",
            >= 17 and < 23 => "Добрый вечер!",
            _ => "Доброй ночи!"
        };
    }
}
