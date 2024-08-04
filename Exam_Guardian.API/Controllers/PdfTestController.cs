//using Exam_Guardian.core.IService;
//using Exam_Guardian.infra.Service;
//using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Mvc;
//using Rotativa.AspNetCore;

//namespace Exam_Guardian.API.Controllers
//{


//    [ApiController]
//    [Route("api/[controller]/[action]")]
//    public class PdfController : ControllerBase
//    {
//        private readonly PdfService _pdfService;
//        private readonly IEmailService _emailService;
//        public PdfController(PdfService pdfService, IEmailService emailService)
//        {
//            _pdfService = pdfService;
//            _emailService = emailService;
//        }

//        //[HttpPost]
//        //public async Task<IActionResult> GeneratePdf([FromBody] string htmlContent)
//        //{
//        //    if (string.IsNullOrWhiteSpace(htmlContent))
//        //    {
//        //        return BadRequest(new { Message = "HTML content cannot be empty." });
//        //    }
//        //    htmlContent =HtmlContentGenerator.GenerateExamHtml("Math Exam", "August 1, 2024", "John Doe", "C12345", 150.00m, "Room 101, Exam Building");

//        //    var pdfStream = await _pdfService.GeneratePdfAsync(htmlContent);
//        //    var fileName = "GeneratedReport.pdf";

//        //    return File(pdfStream, "application/pdf", fileName);
//        //}


//        //[HttpPost]
//        //public async Task<IActionResult> SendEmail([FromBody] string htmlContent)
//        //{
//        //    if (string.IsNullOrWhiteSpace(htmlContent))
//        //    {
//        //        return BadRequest(new { Message = "HTML content cannot be empty." });
//        //    }
//        //    htmlContent = HtmlContentGenerator.GenerateExamHtml("Math Exam", "August 1, 2024", "John Doe", "C12345", 150.00m, "Room 101, Exam Building");

//        //    var pdfStream = await _pdfService.GeneratePdfAsync(htmlContent);
//        //    var fileName = "GeneratedReport.pdf";

//        //    await _emailService.SendEmail(new core.DTO.SendEmailViewModel
//        //    {
//        //        Title="",
//        //        Body=htmlContent,
//        //        Receiver="albettardeaa@gmail.com"
//        //    });
//        //    return Ok(1);
//        //   // return File(pdfStream, "application/pdf", fileName);
//        //}



//    }

//}
