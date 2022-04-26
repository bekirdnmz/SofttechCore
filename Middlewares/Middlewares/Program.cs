var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

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
//    await context.Response.WriteAsync("Talebiniz, middleware'a ulaştı.");
//});

app.Map("/test", xapp =>
{
    xapp.Run(async (context) =>
    {
        var isParameterExist = context.Request.Query.ContainsKey("id");
        if (isParameterExist)
        {
            var id = int.Parse(context.Request.Query["id"]);
            await context.Response.WriteAsync($"{id} degeri ile test basarili.");
        }
        else
        {
            await context.Response.WriteAsync("id parametresi eksik");
        }
    });
});


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
