namespace Para.Api.Model
{
    public class RabbitMQConfig
    {
        public string HostName { get; set; } = "localhost";
        public string QueueName { get; set; } = "email_queue";
        public string UserName { get; set; } = "guest";
        public string Password { get; set; } = "guest";
    }
}
