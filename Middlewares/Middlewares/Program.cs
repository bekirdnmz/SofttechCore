using Middlewares.Services;
using Middlewares.Extensions;
using Middlewares.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddSingleton<IProductService, ProductService>();
//builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddScoped<IProductService, ProductService>();


var app = builder.Build();




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseWelcomePage();
//app.Run(async (context) =>
//{
//    await context.Response.WriteAsync("Talebiniz, middleware'a ulasti.");
//});

//app.Map() ile yazdığımız middleware, aşağıdaki extension metoda taşındı:
app.UseProductIsExistTestPage();

app.Use(async (context, next) =>
{
    Console.WriteLine($"{context.Request.Path} -  {context.Request.Method}");
    await next.Invoke();
});

//app.UseMiddleware<IECheckerMiddleware>();
//app.UseMiddleware<CreaateResponseMiddleware>();
//app.UseMiddleware<RedirectToPageMiddleware>();

app.UseIEChecker();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
