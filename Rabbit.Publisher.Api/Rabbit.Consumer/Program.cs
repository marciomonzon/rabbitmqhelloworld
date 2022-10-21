using Rabbit.Model.Entities;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

var factory = new ConnectionFactory() 
{ 
    HostName = "localhost",
    UserName = "admin",
    Password = "123456"
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare(queue: "RabbitMessagesQueue",
                         durable: false,
                         exclusive: false,
                         autoDelete: false,
                         arguments: null);

    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var jsonMessage = Encoding.UTF8.GetString(body);

        RabbitMessage rabbitMessage = JsonSerializer.Deserialize<RabbitMessage>(jsonMessage);

        Console.WriteLine($"Titulo: {rabbitMessage.Titulo}; Texto: {rabbitMessage.Texto}; Id: {rabbitMessage.Id}");
    };

    channel.BasicConsume(queue: "RabbitMessagesQueue",
                         autoAck: true,
                         consumer: consumer);

    Console.WriteLine(" Press [enter] to exit.");
    Console.ReadLine();
}
