using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Web.Http;

namespace Elektronski_Dnevnik.Controllers
{[Authorize (Roles="administrator")]
    public class EmailController : ApiController
    {[Route("send_e-mail")]
        public void PostSendMail()
        {
            string subject = "School Info ";
            string body = "Dear Parent/Guardian, a new grade was given to your child today.";
            string FromMail = ConfigurationManager.AppSettings["from"];
            string emailTo = "ksenijica83@hotmail.com";
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["smtpServer"]);
            mail.From = new MailAddress(FromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.Body = body;
            SmtpServer.Port = int.Parse(ConfigurationManager.AppSettings["smtpPort"]);
            SmtpServer.Credentials = new System.Net.NetworkCredential(ConfigurationManager.AppSettings["from"], ConfigurationManager.AppSettings["password"]);
            SmtpServer.EnableSsl = bool.Parse(ConfigurationManager.AppSettings["smtpSsl"]);
            SmtpServer.Send(mail);
        }
    }
}

