namespace Middlewares.Infrastructure
{
    public class IECheckerMiddleware
    {
        //bu middleware, gelen request üzerinde güncelleme yapar.
        RequestDelegate next;
        public IECheckerMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            //eğer request IE tarayıcısından geliyorsa, bu bilgiyi httpContext Items içinde sakla:
            httpContext.Items["IE"] = httpContext.Request.Headers["User-Agent"].ToString().Contains("Trident");

            await next.Invoke(httpContext);
        }
    }
}
