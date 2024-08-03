using DinkToPdf;
using DinkToPdf.Contracts;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaperKind = DinkToPdf.PaperKind;

namespace Exam_Guardian.infra.Service
{
    public class PdfService
    {
        private readonly IConverter _pdfConverter;

        public PdfService(IConverter pdfConverter)
        {
            _pdfConverter = pdfConverter;
        }

        public async Task<MemoryStream> GeneratePdfAsync(string htmlContent)
        {
            var pdfDocument = new HtmlToPdfDocument
            {
                GlobalSettings = {
                DocumentTitle = "Generated PDF",
                PaperSize = PaperKind.A4
            },
                Objects = {
                new ObjectSettings
                {
                    HtmlContent = htmlContent,
                    
                    WebSettings = { DefaultEncoding = "utf-8" }
                }
            }
            };

            var pdfBytes = _pdfConverter.Convert(pdfDocument);
            var memoryStream = new MemoryStream(pdfBytes);
            return memoryStream;
        }
    }
}
