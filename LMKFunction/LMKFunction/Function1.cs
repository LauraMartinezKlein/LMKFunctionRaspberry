namespace LMKFunction
{
    using System;
    using System.Threading.Tasks;
    using LMKFunction.Models;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;

    public static class Function1
    {
        [FunctionName("Function1")]
        public static async Task RunAsync(
            [ServiceBusTrigger(
                    "colalmk",
                    Connection = "MyConn"
                    )]string myQueueItem,
            [CosmosDB(
                    databaseName:"dbParcial2",
                    collectionName:"Items",
                    ConnectionStringSetting = "strCosmos"
                    )]IAsyncCollector<object> datos,
            ILogger log)
        {
            try
            {
                log.LogInformation($"C# ServiceBus queue trigger function processed message: {myQueueItem}");
                var data = JsonConvert.DeserializeObject<Data>(myQueueItem);
                await datos.AddAsync(data);
            }
            catch (Exception ex)
            {
                log.LogError($"No fue posible insertar datos: {ex.Message}");
            }
        }
    }
}
