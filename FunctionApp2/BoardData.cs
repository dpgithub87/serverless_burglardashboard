using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Data.SqlClient;
using BlazorApp.Data;
using System.Collections.Generic;
using Microsoft.Azure.Cosmos.Table;
using FunctionApp2;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;

namespace Serverless.BurglarAlarm
{
    public static class BoardData
    {
        [FunctionName("BoardData")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a Get request.");

            string boardName = req.Query["boardName"];
            List<BoardTransaction> lstBoardTransaction = new List<BoardTransaction>();

            if (String.IsNullOrEmpty(boardName))
            {
                return new OkObjectResult(lstBoardTransaction);
            }

            lstBoardTransaction = FetchBoardTransactionDB(boardName);

            return new OkObjectResult(lstBoardTransaction);
        }
        private static List<BoardTransaction> FetchBoardTransactionDB(string boardName)
        {

            Task<List<BoardTransaction>> _lstBoardTransactions = GetBoardTransactionDB(boardName);
            _lstBoardTransactions.Wait();

            return _lstBoardTransactions.Result;
        }

        public static async Task<List<BoardTransaction>> GetBoardTransactionDB(string _hostCode)
        {
            List<BoardTransaction> _records = new List<BoardTransaction>();

            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("saburglaralarm", "35f5xbui4s9ZrwzKhT7XD4J7b96xa+YzkZt9ScS2szv7FGV1LP0yhtmurQPpQT2ZQbQh3PSoqS8lKWR9tMHw6w=="), true);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable _boardTransaction = tableClient.GetTableReference("BoardTransactions");

            //_linkTable.CreateIfNotExists();

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<BoardTransactionEntity> query = new TableQuery<BoardTransactionEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, _hostCode));

            // Print the fields for each customer.
            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<BoardTransactionEntity> resultSegment = await _boardTransaction.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;

                foreach (var entity in resultSegment.Results)
                {
                    BoardTransaction _summary = new BoardTransaction
                    {
                        BoardName = entity.PartitionKey,
                        CreatedDateTime = entity.Timestamp.DateTime,
                        Zone1 = entity.Zone1,
                        Zone2 = entity.Zone2,
                        Zone3 = entity.Zone3,
                        Zone4 = entity.Zone4,
                        Zone1Name = entity.Zone1Name,
                        Zone2Name = entity.Zone2Name,
                        Zone3Name = entity.Zone3Name,
                        Zone4Name = entity.Zone4Name
                    };

                    _records.Add(_summary);
                }
            } while (token != null);


            return _records;
        }



        [FunctionName("negotiate")]
        public static SignalRConnectionInfo GetSignalRInfo(
           [HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequest req,
           [SignalRConnectionInfo(HubName = "chat")] SignalRConnectionInfo connectionInfo)
        {
            return connectionInfo;
        }

        [FunctionName("messages")]
        public static Task SendMessage(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post")] object message,
            [SignalR(HubName = "chat")] IAsyncCollector<SignalRMessage> signalRMessages)
        {
            return signalRMessages.AddAsync(
                new SignalRMessage
                {
                    Target = "newMessage",
                    Arguments = new[] { message }
                });
        }
    }
}
