using Backend_Final.Models.Emails;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace Backend_Final.Services
{
    public class EmailServices : IEmailServices
    {
        private const string templatePath = @"Views/shared/{0}.cshtml";
        private readonly SMTPConfigModel _smtpConfig;
        public async Task SendTestEmail(UserEmailOptions userEmailOptions)
        {
            userEmailOptions.Subject = "This is the test email Subject from Atilla's project";
            userEmailOptions.Body = GetEmailBody("_Comment");

            await SendEmail(userEmailOptions);
        }
        public EmailServices(IOptions<SMTPConfigModel> smtpConfig)
        {
            _smtpConfig = smtpConfig.Value;
        }
        private async Task SendEmail(UserEmailOptions userEmailOptions)
        {
            MailMessage mail = new()
            {
                Subject = userEmailOptions.Subject,
                Body = userEmailOptions.Body,
                From = new MailAddress(_smtpConfig.SendAddress, _smtpConfig.SenderDisplayName),
                IsBodyHtml = _smtpConfig.isBodyHTML
            };
            foreach (var toEmail in userEmailOptions.ToEmails)
            {
                mail.To.Add(toEmail);
            }
            NetworkCredential networkCredential = new(_smtpConfig.UserName, _smtpConfig.Password);

            SmtpClient smtpClient = new()
            {
                Host = _smtpConfig.Host,
                Port = _smtpConfig.Port,
                EnableSsl = _smtpConfig.EnableSSL,
                UseDefaultCredentials = _smtpConfig.UseDefaultCredentials,
                Credentials = networkCredential
            };
            mail.BodyEncoding = Encoding.Default;
            await smtpClient.SendMailAsync(mail);


        }
        private string GetEmailBody(string templateName)
        {
            var body = File.ReadAllText(string.Format(templatePath, templateName));
            return body;
        }
    }
}
