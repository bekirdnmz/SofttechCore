using Serilog;


Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();

Log.Information("Uygulama ayaga kalkiyor");



var builder = WebApplication.CreateBuilder(args);

try
{
    int x = 0;
    int result = 3 / x;
}
catch (Exception ex)
{
    Log.Fatal(ex, "Bir hata oluştu...");
    
}
finally
{
    Log.Information("Operasyon tamamlandı");
    Log.CloseAndFlush();
} 

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
