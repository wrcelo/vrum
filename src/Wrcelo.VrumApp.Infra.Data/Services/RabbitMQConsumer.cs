using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using Wrcelo.VrumApp.Core.Events;
using Wrcelo.VrumApp.Domain.Entity;
using Wrcelo.VrumApp.Domain.Repository;
using Wrcelo.VrumApp.Infra.Data.Configs;

namespace Infra.Services;

public class RabbitMQConsumer : BackgroundService
{
    private readonly IConnection _connection;
    private readonly IModel _channel;
    private readonly RabbitMQConfig _config;
    private readonly IServiceProvider _serviceProvider;

    public RabbitMQConsumer(
        RabbitMQConfig config,
        IServiceProvider serviceProvider)
    {
        _config = config;
        _serviceProvider = serviceProvider;

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

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var consumer = new EventingBasicConsumer(_channel);

        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var evento = JsonSerializer.Deserialize<MotorcyclePostedEvent>(message);


            if (evento.Year == 2024)
            {
                using var scope = _serviceProvider.CreateScope();
                var repository = scope.ServiceProvider.GetRequiredService<IMotorcycleNotificationRepository>();

                var notification = new MotorcycleNotification
                {
                    MotorcycleGuid = evento.Guid,
                    Model = evento.Model,
                    Year = evento.Year,
                    Date = DateTime.UtcNow
                };

                await repository.AddMotorcycleNotificationAsync(notification);
            }
        };

        _channel.BasicConsume(
            queue: _config.QueueName,
            autoAck: true,
            consumer: consumer);

        return Task.CompletedTask;
    }

    public override void Dispose()
    {
        _channel.Close();
        _connection.Close();
        base.Dispose();
    }
}