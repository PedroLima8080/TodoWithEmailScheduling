using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Todo.Messaging;

var messageService = new MessageService();
new EventingBasicConsumer(messageService.emailChannel);

var consumer = new EventingBasicConsumer(messageService.emailChannel);
consumer.Received += (model, ea) =>
{
    Task.Run(() =>
    {
        Thread.Sleep(5000);
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($" [x] Received '{message}'");
    });
};

messageService.emailChannel.BasicConsume(queue: "myQueue", autoAck: true, consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();