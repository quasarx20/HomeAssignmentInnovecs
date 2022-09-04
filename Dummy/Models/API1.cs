namespace Dummy.Models
{

       public class API1Input
        {

            public string? ContactAddress { get; set; }  
            public string? WarehouseAdress { get; set; }
            public int[]? packageDimesions { get; set; }
           
        }

        public class API1Output
        { 
            public int Total { get; set; }
        }
    }

    
