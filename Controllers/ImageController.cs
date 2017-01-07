using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using System.Linq;
using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;

namespace WebApplication.Controllers
{
    public class Image: Controller
    {
        private readonly ApplicationDbContext _DbContext;
        private IHostingEnvironment _environment;

        public Image (ApplicationDbContext DbContext,
                        IHostingEnvironment environment)
        {
            _DbContext = DbContext;
            _environment = environment;
        }

        [HttpGet]
        [AllowAnonymousAttribute]
        public FileStreamResult GetImage(int ImageId)
        {
            var imageResult = _DbContext.Images.ToList().Where(p => p.Id == ImageId).FirstOrDefault();
            Stream stream = new MemoryStream(imageResult.Data);
            return new FileStreamResult(stream, imageResult.Type);
        }

        public IActionResult Add ()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Models.Image image, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                if (file != null && file.Length > 0)
                {
                    var uploads = Path.Combine(_environment.WebRootPath, "uploads");
                    using (var fileStream = new FileStream(Path.Combine(uploads, file.FileName), FileMode.Create))
                    {
                        file.CopyToAsync(fileStream);
                        image.Data = new byte[fileStream.Length];
                        fileStream.Read(image.Data,0,image.Data.Length);
                        image.Name = file.FileName;
                        image.Type = file.ContentType;
                    }
                }
                
                _DbContext.Images.Add(image);
                _DbContext.SaveChanges();
                return View(image);
            }
            return View(image);
        }
    }
}