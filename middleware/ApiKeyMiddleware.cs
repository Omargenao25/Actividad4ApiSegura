namespace Actividad4ApiSegura.middleware
{
    public class ApiKeyMiddleware
    {
        private readonly RequestDelegate _next;
        private const string ApiKeyHeaderName = "X-API-Key";

      public ApiKeyMiddleware(RequestDelegate next)
      { 
            _next = next; 
      }

        public async Task InvokeAsync(HttpContext context, IConfiguration configuration)
        {
            // Permitir Swagger sin autenticación (opcional)
            if (context.Request.Path.StartsWithSegments("/swagger"))
            {
                await _next(context);
                return;
            }

            if (!context.Request.Headers.TryGetValue(ApiKeyHeaderName, out var extractedApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("API Key no proporcionada.");
                return;
            }

            var apiKey = configuration["ApiSettings:ApiKey"];

            if (!apiKey.Equals(extractedApiKey))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("API Key inválida.");
                return;
            }

            await _next(context);
        }

    }
}
