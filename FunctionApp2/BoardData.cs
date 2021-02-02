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

namespace Serverless.BurglarAlarm
{
    public static class BoardData
    {
        [FunctionName("BCSC3AuthSupport")]
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
            return lstBoardTransaction;
        }
    }
}
