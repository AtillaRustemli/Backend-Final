using MimeKit;
using System.Net.Mail;

namespace Backend_Final.Services
{
    public interface IEmailServices
    {
        MimeMessage CreateEmail(string subject, string message, List<string> addresses);
        void SendEmail(MimeMessage message);
    }
}
