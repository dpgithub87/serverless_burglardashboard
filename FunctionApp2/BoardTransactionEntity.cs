using Microsoft.Azure.Cosmos.Table;
using System;
using System.Collections.Generic;
using System.Text;

namespace FunctionApp2
{
   public class BoardTransactionEntity : TableEntity
    {

        public BoardTransactionEntity(string hostcode, string shortcode)
        {
            this.PartitionKey = hostcode;
            this.RowKey = shortcode;
        }

        public BoardTransactionEntity() { }

        public string Zone1Name { get; set; }
        public string Zone2Name { get; set; }
        public string Zone3Name { get; set; }
        public string Zone4Name { get; set; }

        public bool Zone1 { get; set; }        
        public bool Zone2 { get; set; }
        public bool Zone3 { get; set; }
        public bool Zone4 { get; set; }


    }
}
