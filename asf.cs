using YourProjectName.Middleware; // Не забудьте добавить using для вашего пространства имен

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var app = builder.Build();

// Добавляем наш кастомный Middleware в конвейер
app.UseMiddleware<ApiKeyAuthMiddleware>();

app.MapControllers();

app.Run();
