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
        [AllowAnonymous]
        public IActionResult GetImage(int ImageId)
        {
            var imageResult = _DbContext.Images.ToList().Where(p => p.Id == ImageId).FirstOrDefault();
            return View(imageResult);
        }

        [HttpGet]
        [AllowAnonymous]
        public FileStreamResult GetImageForDisplay (int ImageId)
        {
            var imageResult = _DbContext.Images.ToList().Where(p => p.Id == ImageId).FirstOrDefault();
            Stream fileResult = new MemoryStream(imageResult.Data, false);
            return new FileStreamResult(fileResult,imageResult.Type);
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
                    MemoryStream ms = new MemoryStream();
                    file.CopyTo(ms);
                    image.Data = ms.ToArray();
                    image.Name = file.FileName;
                    image.Type = file.ContentType;
                }
                
                _DbContext.Images.Add(image);
                _DbContext.SaveChanges();
                return View(image);
            }
            return View(image);
        }

        public static byte[] ReadFully(Stream input)
        {
            byte[] buffer = new byte[16*1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }
    }
}