namespace RabbitMQ.API.Data
{
    public interface IMessageProducer
    {
        void SendMessage<T>(T message);
    }
}
