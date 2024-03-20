using Marketify.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Marketify.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


    }
}
