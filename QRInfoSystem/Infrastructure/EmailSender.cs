using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;

namespace QRInfoSystem.Infrastructure
{
    public static class EmailSender
    {
        public static void Send(ICollection<string> users, string body,string subject)
        {
            if (users.Count == 0)
            {
                return;
            }

            SmtpClient client = new SmtpClient();   
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.Timeout = 10000;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("qrinfosystem@gmail.com", "zxcvbasdfg");

            MailMessage mm = new MailMessage();
            mm.From = new MailAddress("qrinfosystem@gmail.com");
            foreach (var email in users)
            {
                mm.To.Add(new MailAddress(email));   
            }

            mm.BodyEncoding = UTF8Encoding.UTF8;
            mm.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            mm.Body = body;
            mm.Subject = subject;
            mm.IsBodyHtml = true;

            client.Send(mm);
        }
    }
}