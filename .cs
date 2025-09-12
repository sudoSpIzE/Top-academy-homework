using YourProjectName.Middleware; // Не забудьте добавить using для вашего пространства имен

var builder = WebApplication.CreateBuilder(args);

// Добавляем сервисы контроллеров
builder.Services.AddControllers();

// Регистрируем сервисы для логирования (обычно уже добавлены по умолчанию)
// builder.Logging уже настроен в CreateBuilder

var app = builder.Build();

// Добавляем наш кастомный Middleware в конвейер
app.UseMiddleware<ResponseTimeMiddleware>();

app.MapControllers();

app.Run();
