namespace Exam_Guardian.API.middleware
{
    public class JwtTokenLoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtTokenLoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["access_token"].FirstOrDefault();
            Console.WriteLine($"Token received: {token}");

            await _next(context);
        }
    }

}
