using RabbitMQ.Client;
using Wrcelo.VrumApp.Infra.Data.Configs;
using IModel = RabbitMQ.Client.IModel;

namespace Infra.Data.Services;

public class RabbitMQService : IDisposable
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly RabbitMQConfig _config;

    public RabbitMQService(RabbitMQConfig config)
    {
        _config = config;

        var factory = new ConnectionFactory()
        {
            HostName = _config.HostName,
            UserName = _config.UserName,
            Password = _config.Password,
            Port = 5672
        };

        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(
            queue: _config.QueueName,
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    public void Publish(string message)
    {
        var body = System.Text.Encoding.UTF8.GetBytes(message);

        _channel.BasicPublish(
            exchange: "",
            routingKey: _config.QueueName,
            basicProperties: null,
            body: body);
    }

    public void Dispose()
    {
        _channel?.Close();
        _connection?.Close();
    }
}