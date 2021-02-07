using System;

namespace BlazorApp.Data
{
    public class BoardTransaction
    {
        public int Id { get; set; }
        public string BoardName {get;set;}
        public string Zone1 { get; set; }

        public bool Zone2 { get; set; }

        public string Zone3 { get; set; }

        public string Zone4 { get; set; }

        public DateTime SourceCreatedDateTime { get; set; }

        public DateTime CreatedDateTime { get; set; }
      }

    }
    
