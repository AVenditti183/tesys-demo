using System;
using System.Linq;
using MassTransit;
using MassTransit.RabbitMqTransport;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Worker.Infrastructures.RabbitMQ
{
    public static class RabbitMqExtensions
    {
        public static void AddRabbitMQ(this IServiceCollection services)
        {
            services.AddSingleton(provider => Bus.Factory.CreateUsingRabbitMq(
                cfg =>
                {
                    var configuration = provider.GetService<IConfiguration>();
                    var connectionString = configuration["RABBITMQ_HOST"];
                    var vhost = configuration["RABBITMQ_VHOST"];
                    var username = configuration["RABBITMQ_USERNAME"];
                    var password = configuration["RABBITMQ_PASSWORD"];

                    cfg.Host(connectionString, vhost, h =>
                    {
                        h.Username(username);
                        h.Password(password);
                    });

                    var configs = provider
                        .GetServices<IMassTransitEndpointConfiguration>()
                        .ToArray();
                    Array.ForEach(
                        array: configs,
                        action: x => cfg.ReceiveEndpoint(
                            queueName: x.Queue,
                            configureEndpoint: e => e.RegisterConsumers(x.ConsumerTypes, t => provider.GetService(t))
                        )
                    );
                }));
            services.AddSingleton<IBus>(provider => provider.GetRequiredService<IBusControl>());
            services.AddSingleton<IHostedService, BusService>();
        }

        private static void RegisterConsumers(
            this IRabbitMqReceiveEndpointConfigurator endpoint,
            Type[] consumerTypes,
            Func<Type, object> consumerFactory
        )
        {
            endpoint.UseMessageRetry(config => config.SetRetryPolicy(x => x.Interval(5, TimeSpan.FromSeconds(1))));

            foreach (var consumerType in consumerTypes)
                endpoint.Consumer(consumerType, consumerFactory);
        }
    }
}