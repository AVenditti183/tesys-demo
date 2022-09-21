using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionMicroservices
{
    public class Function2
    {
        [FunctionName("Function2")]
        public void Run([QueueTrigger("lazio", Connection = "StorageQueueConnectionString")] string myQueueItem, ILogger log)
        {
            log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
        }
    }
}