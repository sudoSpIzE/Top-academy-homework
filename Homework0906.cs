using Microsoft.Extensions.DependencyInjection;
using System;

namespace MusicPlayerApp
{
    // Задание 2: Интерфейс ILogger
    public interface ILogger
    {
        void Log(string message);
    }

    // Задание 3: Класс ConsoleLogger
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }

    // Задание 4: Интерфейс IMusicGenre (в задании указано IMusic, но лучше использовать IMusicGenre)
    public interface IMusicGenre
    {
        string GetGenre();
    }

    // Задание 5: Класс ClassicalMusic
    public class ClassicalMusic : IMusicGenre
    {
        public string GetGenre()
        {
            return "Classical";
        }
    }

    // Задание 6: Класс MusicPlayer
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

    class Program
    {
        static void Main(string[] args)
        {
            // Задание 7: Создание DI-контейнера и регистрация сервисов
            var services = new ServiceCollection();
            
            services.AddSingleton<ILogger, ConsoleLogger>();
            services.AddSingleton<IMusicGenre, ClassicalMusic>();
            services.AddSingleton<MusicPlayer>();

            // Задание 8: Создание ServiceProvider и получение экземпляра MusicPlayer
            var serviceProvider = services.BuildServiceProvider();
            var musicPlayer = serviceProvider.GetRequiredService<MusicPlayer>();

            // Вызов метода PlayMusic
            musicPlayer.PlayMusic();

            // Очистка ресурсов
            serviceProvider.Dispose();
        }
    }
}
