namespace Dummy.Models
{

    public class API3Input
    {

        public string?  source       { get; set; }
        public string?  destination  { get; set; }
        public int[]?   packages      { get; set; }

    }

    public class API3Output
    {
        public int quote { get; set; }
    }
}
