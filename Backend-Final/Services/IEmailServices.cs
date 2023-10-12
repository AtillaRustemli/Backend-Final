using Backend_Final.Models.Emails;

namespace Backend_Final.Services
{
    public interface IEmailServices
    {
        Task SendTestEmail(UserEmailOptions userEmailOptions);
    }
}