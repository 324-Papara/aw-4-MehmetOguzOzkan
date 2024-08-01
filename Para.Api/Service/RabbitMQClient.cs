using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Para.Api.Model;
using RabbitMQ.Client;
using System.Text;

namespace Para.Api.Service
{
    public class RabbitMQClient : IRabbitMQClient
    {
        private readonly RabbitMQConfig _config;

        public RabbitMQClient(IOptions<RabbitMQConfig> config)
        {
            _config = config.Value;
        }

        public void PublishEmailToQueue(EmailMessage emailMessage)
        {
            var factory = new ConnectionFactory() { HostName = _config.HostName, UserName = _config.UserName, Password = _config.Password };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare(queue: _config.QueueName, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(emailMessage));

            channel.BasicPublish(exchange: "", routingKey: _config.QueueName, basicProperties: null, body: body);
        }
    }
}
