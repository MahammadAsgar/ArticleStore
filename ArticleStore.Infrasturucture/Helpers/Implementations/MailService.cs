using ArticleStore.Infrasturucture.Helpers.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ArticleStore.Infrasturucture.Helpers.Implementations
{
    public class MailService : IMailService
    {
        public MailService()
        {

        }
        public async Task Activate(string to, int num)
        {
            MailMessage mail = new MailMessage();
            mail.Subject = "Activate";
            mail.Body = num.ToString();
            mail.From = new MailAddress("asgarlimahammad1@gmail.com", "Mahammad Asgarli", System.Text.Encoding.UTF8);
            mail.To.Add(to);
            SmtpClient smtp = new SmtpClient();
            smtp.Credentials = new NetworkCredential("asgarlimahammad1@gmail.com", "Asgarli670");
            smtp.Port = 587;
            smtp.Host = "smtp.office365.com";
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(mail);
        }
    }
}
