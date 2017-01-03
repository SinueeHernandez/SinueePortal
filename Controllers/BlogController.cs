using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using WebApplication.Models;
using System.Linq;

namespace WebApplication.Controllers
{
    public class Blog : Controller
    {
        private readonly ApplicationDbContext _DbContext;

        public Blog (ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }
        
        // GET: /Account/Login
        [HttpGet]
        [AllowAnonymous]
        public IActionResult Index(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(_DbContext.Posts.ToList());
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Post(int PostId, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(_DbContext.Posts.FirstOrDefault(p => p.Id == PostId));
        }

        public IActionResult NewPost()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult NewPost(Post post)
        {
            if (ModelState.IsValid)
            {
                _DbContext.Posts.Add(post);
                _DbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(post);
        }
    }
}