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

        public bool Zone1 { get; set; }
        public bool Zone2 { get; set; }
        public bool Zone3 { get; set; }
        public bool Zone4 { get; set; }

    }
}
