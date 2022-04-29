using courses.Business;
using courses.Business.Mapper;
using courses.DataAccess.Data;
using courses.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Net.Http.Headers;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepository, EFCourseRepository>();
builder.Services.AddMemoryCache();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddDistributedSqlServerCache(opt =>
{
    opt.ConnectionString = builder.Configuration.GetConnectionString("cacheDb");
    opt.SchemaName = "dbo";
    opt.TableName = "TestCache";

});

builder.Services.AddResponseCaching();



builder.Services.AddAutoMapper(typeof(MapProfile));

var connectionString = builder.Configuration.GetConnectionString("coursesDb");

builder.Services.AddDbContext<CourseDbContext>(opt => opt.UseSqlServer(connectionString));




var app = builder.Build();
app.Lifetime.ApplicationStarted.Register(() =>
{
    //Controller'da dependency injection olarak kullanmak isteniyorsa; ilgili ayarlar burada yapılmalı.
    var currentTime = DateTime.Now.ToString();
    var encodedTime = Encoding.UTF8.GetBytes(currentTime.ToString());
    var option = new DistributedCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(45));

    app.Services.GetService<IDistributedCache>().Set("cachedTime", encodedTime, option);
});

//app.UseCors();
app.UseResponseCaching();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
//Böyle bir middleware çok sağlıklı değil. Bunun yerine, koşula dayalı middleware kullanılabilir.
//app.Use(async (context, next) =>
//    {
//        await next.Invoke();

//        var scope = context.RequestServices.CreateScope();
//        var dbContext = scope.ServiceProvider.GetRequiredService<CourseDbContext>();
//        await dbContext.Database.EnsureCreatedAsync();

//    } 

//);
//var scope = app.Services.CreateScope();
//var dbContext = scope.ServiceProvider.GetRequiredService<CourseDbContext>();
//await dbContext.Database.EnsureCreatedAsync();

app.Use(async (context, next) =>
{
    context.Response.GetTypedHeaders().CacheControl = new CacheControlHeaderValue()
    {
        MaxAge = TimeSpan.FromMinutes(1),
        Public = true
    };

    context.Response.Headers[HeaderNames.Vary] = new string[] { "Accept-Encoding" };

    await next();

});



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program { }