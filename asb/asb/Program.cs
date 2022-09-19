// See https://aka.ms/new-console-template for more information

using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using asb.dto;
using Azure.Messaging.ServiceBus;
using Microsoft.Azure.ServiceBus;

var policy = new RetryExponential(
    minimumBackoff: TimeSpan.FromSeconds(10),
    maximumBackoff: TimeSpan.FromSeconds(30),
    maximumRetryCount: 3);

var connectionString = "Endpoint=sb://as-service-bus.servicebus.windows.net/;SharedAccessKeyName=cesar;SharedAccessKey=0voaavzx/ZzEAxEGbTmE8e0u4399HxjsLWQV8FbUkCg=;EntityPath=anagrafica-articoli";
var topic = "anagrafica-articoli";
var subscription = "Cesar";
var client = new ServiceBusClient(connectionString);
var receiver = client.CreateReceiver(topic, subscription);

var msgs = receiver.ReceiveMessagesAsync();

//var dmsgs = await receiver.ReceiveDeferredMessagesAsync(sequenceNumbers: new List<long>());
//foreach (var serviceBusReceivedMessage in dmsgs)
//{
//    var message = JsonSerializer.Deserialize<ASMessage>(Encoding.UTF8.GetString(serviceBusReceivedMessage.Body));
//    Console.WriteLine($"id: {message.Id} - text: {message.Text} - Date: {message.Date}");
//    await receiver.CompleteMessageAsync(serviceBusReceivedMessage);
//}

await foreach (var msg in msgs)
{
    var message = JsonSerializer.Deserialize<ASMessage>(Encoding.UTF8.GetString(msg.Body));
    Console.WriteLine($"id: {message.Id} - text: {message.Text} - Date: {message.Date} - deliveryCount:{msg.DeliveryCount} now: {DateTime.Now}");

    //await receiver.DeferMessageAsync(msg);
    await receiver.CompleteMessageAsync(msg);
    //throw new Exception();
}

//var process = client.CreateProcessor(topic, subscription, new ServiceBusProcessorOptions()
//{
//    AutoCompleteMessages = true
//});
////var sender = client.CreateSender($"{topic}/{subscription}");
//process.ProcessMessageAsync += async (arg) =>
//{
//    //await arg.DeadLetterMessageAsync(arg.Message);
//    //return;

//    Console.WriteLine("msg errore");
//    throw new Exception();
//    //await sender.SendMessageAsync(new ServiceBusMessage(arg.Message));
//    var message = JsonSerializer.Deserialize<ASMessage>(Encoding.UTF8.GetString(arg.Message.Body));

//    Console.WriteLine($"id: {message.Id} - text: {message.Text} - Date: {message.Date}");
//    //await arg.CompleteMessageAsync(arg.Message);
//};
//process.ProcessErrorAsync += (arg) =>
//{
//    Console.WriteLine(arg.Exception.ToString());
//    return Task.CompletedTask;
//};

//await process.StartProcessingAsync();
Console.WriteLine("Process Start");
Console.ReadKey();

Console.WriteLine("end");