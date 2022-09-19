// See https://aka.ms/new-console-template for more information

using System.Text;
using System.Text.Json;
using asb.dto;
using Azure.Messaging.ServiceBus;

var connectionString = "Endpoint=sb://teacher-asb.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=ymcFgoJ1fNLzFMOxNMxDdcKwOC2+uQoooGI19L446AA=";
var topic = "topic1";
var client = new ServiceBusClient(connectionString);
var sender = client.CreateSender(topic);
var message = new ASMessage
{
    Id = 1,
    Text = "test",
    Date = DateTimeOffset.Now
};

var msg = new ServiceBusMessage(
    Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message))
);
msg.ApplicationProperties.Add("COMPANY", "cesar");
msg.ContentType = "application/json;charset=utf-8";

await sender.SendMessageAsync(msg);

Console.WriteLine("Fatto");