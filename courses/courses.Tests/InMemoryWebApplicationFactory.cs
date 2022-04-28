using courses.DataAccess.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace courses.Tests
{
    public class InMemoryWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test")
                   .ConfigureTestServices(services =>
                   {
                       //1. CourseTextContext'i, InMemory üzerinde oluştur.
                       var option = new DbContextOptionsBuilder<CourseDbContext>().UseInMemoryDatabase("TestDb").Options;
                       services.AddScoped<CourseDbContext>(opt => new CourseTestContext(option));
                       using var scope = services.BuildServiceProvider().CreateScope();
                       var scopedService = scope.ServiceProvider;
                       var db = scopedService.GetRequiredService<CourseDbContext>();
                       db.Database.EnsureCreated();

                   });
            
        }
    }
   
}
