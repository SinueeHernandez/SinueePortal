using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using WebApplication.Models;
using System.Linq;
using System.IO;

namespace WebApplication.Controllers
{
    public class ImageController: Controller
    {
        private readonly ApplicationDbContext _DbContext;

        public ImageController (ApplicationDbContext DbContext)
        {
            _DbContext = DbContext;
        }

        [HttpGet]
        [AllowAnonymousAttribute]
        public FileStreamResult Get(int ImageId)
        {
            var imageResult = _DbContext.Images.ToList().Where(p => p.Id == ImageId).FirstOrDefault();
            Stream stream = new MemoryStream(imageResult.Data);
            return new FileStreamResult(stream, imageResult.Type);
        }
    }
}