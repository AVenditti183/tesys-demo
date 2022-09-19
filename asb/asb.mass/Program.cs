// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using asb.dto;
using MassTransit;
using MassTransit.AzureServiceBusTransport.Topology;
using MassTransit.Topology;

var connectionString = "Endpoint=sb://as-service-bus.servicebus.windows.net/;SharedAccessKeyName=cesar;SharedAccessKey=3ZNZuwIJIw6KDoV/0AYQlq9xs6/eVkhgajYRyPAaYsg=;EntityPath=anagrafica-articoli";
var topic = "anagrafica-articoli";
var subscription = "Cesar";
var bus = Bus.Factory.CreateUsingAzureServiceBus(config =>
    {
        config.Host(connectionString);

        config.SubscriptionEndpoint(subscription, topic, endpoint =>
        {
            endpoint.Handler<ASMessage>(ctx =>
            {
                var message = ctx.Message;
                return Console.Out.WriteLineAsync($"id: {message.Id} - text: {message.Text} - Date: {message.Date} - CompanyId:{message.CompanyId} now: {DateTime.Now}");
            });
        });
    }
);

bus.Start();

bus.Publish<ASMessage>(new ASMessage
{
    Id = 2,
    Text = "ms",
    CompanyId = 4,
    Date = DateTimeOffset.Now
});

Console.WriteLine("Start Bus");
Console.ReadKey();

bus.Stop();