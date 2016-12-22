using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Sinuee Hernandez - Developer.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "You need a hand - just tell me.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
