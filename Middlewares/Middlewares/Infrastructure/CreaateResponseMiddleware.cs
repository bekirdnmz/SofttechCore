namespace Middlewares.Infrastructure
{
    public class CreaateResponseMiddleware
    {
        //Bu middleware, response'a müdahale eder.
        private readonly RequestDelegate _next;

        public CreaateResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Items["IE"] as bool? == true)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                //await context.Response.WriteAsync("IE is not supported");
            }
            await _next.Invoke(context);
        }
    }
}
