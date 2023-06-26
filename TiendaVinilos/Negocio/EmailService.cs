using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("3dad7b74e3f838", "********bfdb");
            server.UseDefaultCredentials = false;
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "sandbox.smtp.mailtrap.io";
        }

        public void armarCorreo(string mailDestino, string asunto, string cuerpo)
        {
            email = new MailMessage();
            email.From = new MailAddress("tiendaVinilos@ecommerce.com");
            email.To.Add(mailDestino);
            email.Subject=(asunto);
            email.IsBodyHtml = true;
            email.Body = cuerpo;
        }

        public void enviarEmail()
        {
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
