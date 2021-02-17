using System;

namespace BlazorApp.Data
{
    public class BoardTransaction
    {
        public int Id { get; set; }
        public string BoardName {get;set;}
        public bool Zone1 { get; set; }

        public bool Zone2 { get; set; }
        public bool Zone3 { get; set; }
        public bool Zone4 { get; set; }


        public DateTime SourceCreatedDateTime { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public string Zone1Name{get;set;}

        public string Zone2Name { get;set;}
        public string Zone3Name { get; set; }
        public string Zone4Name { get; set; }

    }

    }
    
