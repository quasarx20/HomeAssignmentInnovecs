namespace Dummy.Models
{
    

        public class API2Input
        {

            public string? Consignee { get; set; }
            public string? Consignor { get; set; }

            public int[]? cartons { get; set; }

        }

        public class API2Output
        {
            public int amount { get; set; }
        }
    }

  