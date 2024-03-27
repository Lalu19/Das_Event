using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AdminClient.Controllers
{
    public class UploadController : Controller
    {
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<UploadController> _logger;

        public UploadController(IWebHostEnvironment hostingEnvironment, ILogger<UploadController> logger)
        {
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult ImgUploadMultiple(List<IFormFile> files)
        {
            var uploadedFilePaths = new List<string>();

            foreach (var file in files)
            {
                try
                {
                    string filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    filename = EnsureCorrectFilename(filename); // This line is not necessary for multiple files
                    string uploadsFolder = Path.Combine(_hostingEnvironment.WebRootPath, "images");
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + filename;
                    string imagePath = Path.Combine(uploadsFolder, uniqueFileName);
                    file.CopyTo(new FileStream(imagePath, FileMode.Create));
                    uploadedFilePaths.Add("/images/" + uniqueFileName);
                }
                catch (Exception exception)
                {
                    _logger.LogError(exception.Message);
                }
            }

            return Ok(uploadedFilePaths);
        }

        // This method is not needed for multiple file uploads
        private string EnsureCorrectFilename(string filename)
        {
            if (filename.Contains("\\"))
                filename = filename.Substring(filename.LastIndexOf("\\") + 1);

            return filename;
        }
    }
}


