using System;

namespace BlazorApp.Data
{
    public class BoardTransaction
    {
        public int Id { get; set; }
        public string BoardName {get;set;}
        public bool Zone1 { get; set; }

        public string zone1DN { get; set; }
        public bool Zone2 { get; set; }
        public string zone2DN { get; set; }
        public bool Zone3 { get; set; }
        public string zone3DN { get; set; }
        public bool Zone4 { get; set; }
        public string zone4DN { get; set; }
        

        public DateTime SourceCreatedDateTime { get; set; }

        public DateTime CreatedDateTime { get; set; }
      }

    }
    
