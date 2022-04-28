using courses.Business;
using courses.Business.Mapper;
using courses.DataAccess.Data;
using courses.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICourseService, CourseService>();
builder.Services.AddScoped<ICourseRepository, EFCourseRepository>();

builder.Services.AddAutoMapper(typeof(MapProfile));

var connectionString = builder.Configuration.GetConnectionString("coursesDb");

builder.Services.AddDbContext<CourseDbContext>(opt => opt.UseSqlServer(connectionString));



var app = builder.Build();

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


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
