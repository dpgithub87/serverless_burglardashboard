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

namespace Serverless.BurglarAlarm
{
    public static class BoardData
    {
        [FunctionName("BoardData")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
                log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

           List<BoardTransaction> lstBoardTransaction = FetchBoardTransactionDB();

            return new OkObjectResult(lstBoardTransaction);
        }
        private static List<BoardTransaction> FetchBoardTransactionDB()
        {
            
            List<BoardTransaction> lstBoardTransaction = new List<BoardTransaction>();

            lstBoardTransaction.Add(new BoardTransaction(){BoardName = "tstName"}            
            );
            Task<List<BoardTransaction>> _lstBoardTransactions = GetLinks("Board1");
            _lstBoardTransactions.Wait();

            return _lstBoardTransactions.Result;
        }

        public static async Task<List<BoardTransaction>> GetLinks(string _hostCode)
        {
            List<BoardTransaction> _records = new List<BoardTransaction>();

            CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials("saburglaralarm", "35f5xbui4s9ZrwzKhT7XD4J7b96xa+YzkZt9ScS2szv7FGV1LP0yhtmurQPpQT2ZQbQh3PSoqS8lKWR9tMHw6w=="), true);
            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable _linkTable = tableClient.GetTableReference("BoardTransactions");

            _linkTable.CreateIfNotExists();

            // Construct the query operation for all customer entities where PartitionKey="Smith".
            TableQuery<BoardTransactionEntity> query = new TableQuery<BoardTransactionEntity>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, _hostCode));

            // Print the fields for each customer.
            TableContinuationToken token = null;
            do
            {
                TableQuerySegment<BoardTransactionEntity> resultSegment = await _linkTable.ExecuteQuerySegmentedAsync(query, token);
                token = resultSegment.ContinuationToken;

                foreach (var entity in resultSegment.Results)
                {
                    BoardTransaction _summary = new BoardTransaction
                    {
                       BoardName = entity.PartitionKey
                    };

                    _records.Add(_summary);
                }
            } while (token != null);


            return _records;
        }
    }
}
