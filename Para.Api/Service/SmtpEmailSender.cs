using Microsoft.Extensions.Options;
using Para.Api.Model;
using System.Net.Mail;
using System.Net;

namespace Para.Api.Service
{
    public class SmtpEmailSender : IEmailSender
    {
        private readonly SmtpConfig _config;

        public SmtpEmailSender(IOptions<SmtpConfig> config)
        {
            _config = config.Value;
        }

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            var client = new SmtpClient(_config.Host, _config.Port)
            {
                Credentials = new NetworkCredential(_config.UserName, _config.Password),
                EnableSsl = true,
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_config.FromEmail),
                Subject = emailMessage.Subject,
                Body = emailMessage.Body,
                IsBodyHtml = true,
            };

            mailMessage.To.Add(emailMessage.To);

            await client.SendMailAsync(mailMessage);
        }
    }
}
