
using Microsoft.Extensions.DependencyInjection;

public interface ILogger  //Задание 1,2
{
    void Log(string message);
}

public class ConsoleLogger : ILogger // Задание 3
{
    public void Log(string message)
    {
        Console.WriteLine(message);
    }
}

public interface IMusicGenre // Задание 4 
{
    string GetGenre();
}

public class ClassicalMusic : IMusicGenre //Задание 5
{
    public string GetGenre()
    {
        return "Classical";
    }
}

public class MusicPlayer 
{
    private readonly ILogger _logger;
    private readonly IMusicGenre _musicGenre;

    public MusicPlayer(ILogger logger, IMusicGenre musicGenre)
    {
        _logger = logger;
        _musicGenre = musicGenre;
    }

    public void PlayMusic()
    {
        string genre = _musicGenre.GetGenre();
        _logger.Log($"Playing {genre} music...");
    }
}

class Program // Задание 6
{
    static void Main(string[] args)
    {
        var services = new ServiceCollection();

        // Регистрация зависимостей
        services.AddTransient<ILogger, ConsoleLogger>();
        services.AddTransient<IMusicGenre, ClassicalMusic>();
        services.AddTransient<MusicPlayer>();

        var provider = services.BuildServiceProvider();
        var player = provider.GetRequiredService<MusicPlayer>();

        player.PlayMusic();
    }
}
