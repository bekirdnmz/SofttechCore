using courses.Business;
using courses.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace courses.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICourseService courseService;

        public HomeController(ILogger<HomeController> logger, ICourseService courseService)
        {
            _logger = logger;
            this.courseService = courseService;
        }

        public IActionResult Index(int? page=1)
        {
            var itemPerPage = 3;
            var courses = courseService.GetCourses();
            var pagingCourses = courses.OrderBy(x => x.Id)
                                       .Skip((page.Value - 1) * itemPerPage)
                                       .Take(itemPerPage)
                                       .ToList();

            
            ViewBag.TotalPages = Math.Ceiling((decimal)courses.Count() / itemPerPage);
            return View(pagingCourses);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}