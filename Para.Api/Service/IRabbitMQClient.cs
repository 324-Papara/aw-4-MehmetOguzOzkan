using Para.Api.Model;
using System.Net.Mail;

namespace Para.Api.Service
{
    public interface IRabbitMQClient
    {
        void PublishEmailToQueue(EmailMessage emailMessage);
    }
}
