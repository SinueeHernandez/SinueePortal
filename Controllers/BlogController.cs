using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class Blog : Controller
    {

        //
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        public IActionResult NewPost()
        {
            ViewData["Title"] = "New Post creation";
            ViewData["Message"] = "Create a new post here";
            return View();
        }
    }
}