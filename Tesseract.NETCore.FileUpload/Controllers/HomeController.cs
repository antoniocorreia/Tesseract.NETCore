using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Extensions.FileProviders;
using Tesseract;
using System.Drawing;
using Microsoft.AspNetCore.Hosting;
using Tesseract.NETCore.FileUpload.Models.Home;

namespace Tesseract.NETCore.FileUpload.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileProvider fileProvider;
        private IHostingEnvironment _environment;
        
        public HomeController(IFileProvider fileProvider, IHostingEnvironment environment)
        {
            this.fileProvider = fileProvider;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcessFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

           
            using (var engine = new TesseractEngine(Path.Combine(_environment.WebRootPath, "tessdata"), "eng", EngineMode.Default))
            {
                using (var image = new Bitmap(file.OpenReadStream()))
                {

                    using (var page = engine.Process(image))
                    {
                        IndexViewModel model = new IndexViewModel();
                        model.Text = page.GetText();
                        model.MeanConfidence = page.GetMeanConfidence();

                        return View("Index", model);
                    }

                }
            }
            
        }

      
        private string GetContentType(string path)
        {
            var types = GetMimeTypes();
            var ext = Path.GetExtension(path).ToLowerInvariant();
            return types[ext];
        }

        private Dictionary<string, string> GetMimeTypes()
        {
            return new Dictionary<string, string>
            {
                {".txt", "text/plain"},
                {".pdf", "application/pdf"},
                {".doc", "application/vnd.ms-word"},
                {".docx", "application/vnd.ms-word"},
                {".xls", "application/vnd.ms-excel"},
                {".xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"},
                {".png", "image/png"},
                {".jpg", "image/jpeg"},
                {".jpeg", "image/jpeg"},
                {".gif", "image/gif"},
                {".csv", "text/csv"}
            };
        }
    }
}
