using courses.Entities;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using Xunit;

namespace courses.Tests
{
    public class CoursesControllerTest : IClassFixture<InMemoryWebApplicationFactory<Program>>
    {
        private InMemoryWebApplicationFactory<Program> _factory;
        public CoursesControllerTest(InMemoryWebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }
        
        [Fact]
        public async void api_success_test()
        {
            var client = _factory.CreateClient();
            var response = await client.GetAsync("/api/courses");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void api_post_test()
        {
            var course = new Course { Name = "Test Course", Description = "Test Description", StartDate= DateTime.Now, EndDate = System.DateTime.Now, Price = 100, CategoryId=1 };
            var client = _factory.CreateClient();
            var httpContent = new StringContent(JsonConvert.SerializeObject(course), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/courses",httpContent);

            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
            
        }

    }
}