using Middlewares.Infrastructure;
using Middlewares.Services;

namespace Middlewares.Extensions
{
    public static class ApplicationExtensions
    {
        public static IApplicationBuilder UseProductIsExistTestPage(this IApplicationBuilder app, string testUrl="/test")
        {
            app.Map(testUrl, xapp =>
            {
                xapp.Run(async (context) =>
                {
                    var isParameterExist = context.Request.Query.ContainsKey("id");
                    if (isParameterExist)
                    {
                        var id = int.Parse(context.Request.Query["id"]);
                        //Eğer IoC içerisinde yer alan instance, Singleton ya da Transient Life Cycle ile tanımlanmış ise doğrudan bu instance'a HttpContext'in RequestServices özelliği ile erişebilirsiniz.,
                        //Ancak, Scope ile tanımlanmış ise, HttpContext üzerinden bir scope oluşturmalısınız:
                        
                        //var productService = context.RequestServices.GetService<IProductService>();
                        
                        var scoped = context.RequestServices.CreateScope();
                        var productService = scoped.ServiceProvider.GetService<IProductService>();

                        if (productService.IsProductExist(id))
                        {
                            await context.Response.WriteAsync($"{id} id'li urun var");

                        }
                        else
                        {
                            await context.Response.WriteAsync($"{id} id'li urun yok");
                        }
                    }
                    else
                    {
                        await context.Response.WriteAsync("id parametresi eksik");
                    }
                });
            });

            return app;
        }

        public static IApplicationBuilder UseIEChecker(this IApplicationBuilder app)
        {
            app.UseMiddleware<IECheckerMiddleware>();
            app.UseMiddleware<CreaateResponseMiddleware>();
            app.UseMiddleware<RedirectToPageMiddleware>();

            return app;
        }
    }
}
