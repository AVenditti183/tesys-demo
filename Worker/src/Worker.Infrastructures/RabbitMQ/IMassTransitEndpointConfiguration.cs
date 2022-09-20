using System;

namespace Worker.Infrastructures.RabbitMQ
{
    public interface IMassTransitEndpointConfiguration
    {
        string Queue { get; }
        Type[] ConsumerTypes { get; }
    }
}