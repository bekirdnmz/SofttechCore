using DependencyInjectionLC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DependencyInjectionLC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISingletonGuidGenerator singleton;
        private readonly IScopedGuidGenerator scoped;
        private readonly ITransientGuidGenerator transient;

        public HomeController(ILogger<HomeController> logger, ISingletonGuidGenerator singleton, 
                                                              IScopedGuidGenerator scoped, 
                                                              ITransientGuidGenerator transient)
        {
            this.singleton = singleton;
            this.scoped = scoped;
            this.transient = transient;
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Singleton = singleton.Guid;
            ViewBag.Transient = transient.Guid;
            ViewBag.Scoped = scoped.Guid;
            return View();
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