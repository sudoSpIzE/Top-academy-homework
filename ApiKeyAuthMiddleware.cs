using System.Text;

namespace YourProjectName.Middleware
{
    public class ApiKeyAuthMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKeyHeaderName = "X-API-Key";
        // Замените это значение на ваш реальный API-ключ.
        // В реальном приложении его следует хранить в защищенном месте (например, в менеджере секретов или environment variables).
        private const string ValidApiKey = "1234567890"; 

        public ApiKeyAuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 1. Проверяем, присутствует ли заголовок с API-ключом
            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
            {
                // Если заголовок отсутствует, прерываем выполнение и возвращаем ошибку 401
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Authentication failed: API key is missing");
                return;
            }

            // 2. Проверяем, совпадает ли значение ключа с валидным
            if (!ValidApiKey.Equals(extractedApiKey))
            {
                // Если ключ неверный, прерываем выполнение и возвращаем ошибку 401
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Authentication failed: API key is invalid");
                return;
            }

            // 3. Если все проверки пройдены, передаем запрос дальше по конвейеру
            await _next(context);
        }
    }
}
