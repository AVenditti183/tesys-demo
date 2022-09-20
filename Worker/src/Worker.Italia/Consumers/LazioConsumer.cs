using System;
using System.Threading.Tasks;
using MassTransit;
using Worker.Infrastructures.RabbitMQ;
using Worker.Italia.Entities;
using Worker.Italia.Messages.Internal;
using Worker.Italia.Services.Lazio;

namespace Worker.Italia.Consumers
{
    public class LazioConsumer : IConsumer<CreateLazioCommand>
    {
        private readonly ILazioService service;

        public LazioConsumer(ILazioService service)
        {
            this.service = service;
        }

        public Task Consume(ConsumeContext<CreateLazioCommand> context)
        {
            var entity = new LazioEntity()
            {
                Name = context.Message.Name,
                LastName = context.Message.LastName
            };

            service.CreateEntity(entity);
            return Task.CompletedTask;
        }
    }

    public class LazioEndpointConfiguration : IMassTransitEndpointConfiguration
    {
        public string Queue => "lazio-consumer";

        public Type[] ConsumerTypes => new Type[]
        {
            typeof(LazioConsumer)
        };
    }
}