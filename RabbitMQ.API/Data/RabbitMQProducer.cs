using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace RabbitMQ.API.Data
{
    public class RabbitMQProducer : IMessageProducer
    {
        private readonly IConfiguration _config;

        public RabbitMQProducer(IConfiguration config)
        {
            _config = config;
        }

        public void SendMessage<T>(T message)
        {
            var factory = new ConnectionFactory()
            {
                Uri = new Uri(_config["RabbitMQ:Uri"] ?? ""),
            };

            var connection = factory.CreateConnection();

            using (var channel = connection.CreateModel())
            {
                string queueName = "mailQueue";
                string exchangeName = "mailExchange";
                string routingKey = "mail";

                channel.QueueDeclare(queue: queueName,
                                        durable: false,
                                        exclusive: false,
                                        autoDelete: false,
                                        arguments: null);

                channel.ExchangeDeclare(exchangeName, ExchangeType.Direct);

                channel.QueueBind(queueName, exchangeName, routingKey, null);

                var json = JsonSerializer.Serialize(message);
                var body = Encoding.UTF8.GetBytes(json);

                channel.BasicPublish(exchange: exchangeName,
                                        routingKey: routingKey,
                                        basicProperties: null,
                                        body: body);
            }
        }
    }
}
