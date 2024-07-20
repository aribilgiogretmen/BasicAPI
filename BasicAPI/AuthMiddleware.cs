namespace BasicAPI
{
    public class AuthMiddleware
    {
        private readonly RequestDelegate _next;
        private const string API_KEY = "1234567a";

        public AuthMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue("X-API-KEY", out var extractApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("API Key Bulunamadı");
                return;

            }

            if (!API_KEY.Equals(extractApiKey))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Yetkisiz istek");
                return;

            }
            await _next(context);


        }
    }
}
