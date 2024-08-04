using Exam_Guardian.core.Data;
using Exam_Guardian.core.IService;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class FileService: IFileService
    {
     
        private readonly IWebHostEnvironment _environment;
        private readonly List<string> _allowedExtensions = new List<string> { ".jpg", ".jpeg", ".png",".bmp" };
        private readonly long _maxFileSize = 100 * 1024 * 1024; // 20 MB

        public FileService(IWebHostEnvironment environment)
        {
    
            _environment = environment;
        }

        public async Task<string> UploadImageAsync(IFormFile image)
        {
            if (image == null || image.Length == 0)
            {
                throw new Exception("No image file provided");
            }

            if (image.Length > _maxFileSize)
            {
                throw new Exception("File size exceeds the 20 MB limit");
            }

            var fileExtension = Path.GetExtension(image.FileName).ToLowerInvariant();
            if (!_allowedExtensions.Contains(fileExtension))
            {
                throw new Exception("Invalid file type. Only JPG, JPEG, PNG, GIF, and BMP files are allowed.");
            }

            var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads");
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
            var filePath = Path.Combine(uploadsFolder, uniqueFileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return $"uploads/{uniqueFileName}";
        }



        public async Task<string> UploadPdfFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new Exception("file not found ");
            }

            if (file.ContentType != "application/pdf" || Path.GetExtension(file.FileName).ToLower() != ".pdf")
            {
                throw new InvalidOperationException("Invalid file type. Only PDF files are allowed.");
            }

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine(uploadPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"uploads/{fileName}";
        }

    }
}
