using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IService
{
    public interface IFileService
    {
        Task<string> UploadImageAsync(IFormFile image);
        Task<string> UploadPdfFileAsync(IFormFile file);
    }
}
