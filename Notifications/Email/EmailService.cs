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
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.DoWork += delegate
            {
                try
                {
                    SmtpClient smtpClient = new SmtpClient
                    {
                        EnableSsl = false,
                        Port = port,
                        Host = smtpServer,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(userName, password)
                    };
                    MailMessage mailMessage = new MailMessage
                    {
                        From = new MailAddress(userName),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };

                    mailMessage.To.Add(mailName);

                    smtpClient.Send(mailMessage);

                }
                catch (Exception)
                {
                    //TODO
                }
            };
            backgroundWorker.RunWorkerAsync();
        }
    }
}