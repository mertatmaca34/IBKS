using System;
using System.ComponentModel;
using System.Configuration;
using System.Net;
using System.Net.Mail;

namespace Notifications.Email
{
    public class EmailService
    {
        readonly int port = Convert.ToInt16(ConfigurationManager.AppSettings["Port"]);
        readonly string smtpServer = ConfigurationManager.AppSettings["SmtpServer"];
        readonly string userName = ConfigurationManager.AppSettings["Username"];
        readonly string password = ConfigurationManager.AppSettings["Password"];

        public void MailSend(string mailName, string subject, string body)
        {
            var bgw = new BackgroundWorker();
            bgw.DoWork += delegate {
                try
                {
                    SmtpClient client = new SmtpClient
                    {
                        EnableSsl = false,
                        Port = port,
                        Host = smtpServer,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(userName, password)
                    };
                    MailMessage mm = new MailMessage
                    {
                        From = new MailAddress(userName)
                    };
                    mm.To.Add(mailName);
                    mm.Subject = subject;
                    mm.IsBodyHtml = true;
                    mm.Body = body;

                    client.Send(mm);

                }
                catch (Exception)
                {
                    //TODO
                }
            };
            bgw.RunWorkerAsync();
        }
    }
}