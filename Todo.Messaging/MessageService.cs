using RabbitMQ.Client;

namespace Todo.Messaging
{
    public class MessageService
    {
        private IConnection connection;
        public IModel emailChannel;

        public MessageService()
        {
            this.connection = new ConnectionFactory
            {
                HostName = "localhost",
                Port = 5672
            }.CreateConnection();

            emailChannel = connection.CreateModel();
            emailChannel.QueueDeclare(queue: "myQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

    }
}
