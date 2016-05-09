using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Mvc6MovieTutorial.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About Page!";

            return View();
        }

        public IActionResult News()
        {
            ViewData["Message"] = "News from CNN, VICE, or etc will stream on this page.";
            return View();
        }

        public IActionResult Calendar()
        {
            ViewData["Message"] = "A useful personal planning page for appointments, events, etc..";
            return View();
        }

        public IActionResult Projects()
        {
            ViewData["Message"] = "This is where you can place your portfolio.";
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
