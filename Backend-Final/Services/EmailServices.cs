using Backend_Final.Models.Emails;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Encodings;
using System.Net;
using System.Text;

namespace Backend_Final.Services
{
    public class EmailServices
    {
        private const string templatePath = @"Views/shared/{0}.cshtml";
        private readonly EmailConfig _smtpConfig;

        public EmailServices(EmailConfig smtpConfig)
        {
            _smtpConfig = smtpConfig;
        }
        public MimeMessage CreateEmail(string subject,string message,List<string> addresses)
        {
            var to=new List<MailboxAddress>();
            foreach (var address in addresses)
            {
            to.Add(new MailboxAddress(string.Empty, address));
            }

            var emailMessage=new MimeMessage();
            emailMessage.From.Add(new MailboxAddress(_smtpConfig.UserName, _smtpConfig.From));
            emailMessage.Subject = subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Text)
            {
                Text = message
            };

            return emailMessage;

        }
        public void SendEmail(MimeMessage message)
        {
            using(var client=new SmtpClient())
            {
                try
                {
               
                client.Connect("smtp.gmail.com", _smtpConfig.Port, true);
                client.AuthenticationMechanisms.Remove("XOAUTH2");
                client.Authenticate(_smtpConfig.From, _smtpConfig.Password);
                client.Send(message);

                }
                catch(Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                }
                
            }

        }

        //MimeMessage IEmailServices.CreateEmail(string subject, string message, List<string> addresses)
        //{
        //    throw new NotImplementedException();
        //}

        //void IEmailServices.SendEmail(MimeMessage message)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
