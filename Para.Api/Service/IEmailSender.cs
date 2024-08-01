using Para.Api.Model;

namespace Para.Api.Service
{
    public interface IEmailSender
    {
        Task SendEmailAsync(EmailMessage emailMessage);
    }
}
