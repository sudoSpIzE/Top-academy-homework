namespace YourProjectName.Middleware
{
    public class ResponseTimeMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ResponseTimeMiddleware> _logger;

        public ResponseTimeMiddleware(RequestDelegate next, ILogger<ResponseTimeMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // 1. Засекаем время начала обработки запроса
            var startTime = DateTime.UtcNow;

            // 2. Передаем запрос дальше по конвейеру и ждем его выполнения
            await _next(context);

            // 3. После того как запрос обработан, вычисляем продолжительность
            var responseTime = DateTime.UtcNow - startTime;

            // 4. Выводим информацию в консоль
            _logger.LogInformation($"HTTP {context.Request.Method} {context.Request.Path} responded {context.Response.StatusCode} in {responseTime.TotalMilliseconds} ms");
        }
    }
}
