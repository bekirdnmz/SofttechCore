using Filters.Filters;
using Filters.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Filters.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Stopwatch]
        public IActionResult Index()
        {
            return View();
        }
        [NotImplemented]
        public IActionResult Privacy()
        {
            throw new NotImplementedException();
            //return View();
        }
        [Stopwatch]
        public IActionResult GetCustomer()
        {
            Customer customer = new Customer()
            {
                Id = 1,
                Name = "John",
                Address= "123 Main Street",
            };
            return View(customer);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        
    }
}