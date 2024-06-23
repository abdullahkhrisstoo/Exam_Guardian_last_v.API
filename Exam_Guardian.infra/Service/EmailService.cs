using Exam_Guardian.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Exam_Guardian.core.DTO;
using Microsoft.IdentityModel.Tokens;
using Exam_Guardian.core.Utilities.PackagesConstants;

namespace Exam_Guardian.infra.Service
{

    public class EmailService : IEmailService
    {
        public async Task SendEmail(SendEmailViewModel sendEmailViewModel)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress(EmailConstant.GMAIL_EMAIL);
                    mail.To.Add(sendEmailViewModel.Receiver!);
                    mail.Subject = sendEmailViewModel.Title;
                    mail.Body = sendEmailViewModel.Body;

                    if (!string.IsNullOrEmpty(sendEmailViewModel.AttachmentPath))
                    {
                        Attachment attachment = new Attachment(sendEmailViewModel.AttachmentPath);
                        mail.To.Add(sendEmailViewModel.Receiver);
                        mail.Subject = sendEmailViewModel.Title;
                        mail.Body = sendEmailViewModel.Body;

                        if (!string.IsNullOrEmpty(sendEmailViewModel.AttachmentPath))
                        {
                            //Attachment attachment = new Attachment(sendEmailViewModel.AttachmentPath);
                            //mail.Attachments.Add(attachment);
                        }
                        using (SmtpClient smtpServer = new SmtpClient(EmailConstant.GMAIL_HOST))
                        {
                            smtpServer.Port = EmailConstant.GMAIL_PORST;
                            smtpServer.Credentials = new NetworkCredential(EmailConstant.GMAIL_EMAIL, EmailConstant.GMAIL_PASSWORD);
                            smtpServer.EnableSsl = true;
                            await smtpServer.SendMailAsync(mail);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        
    }

}
