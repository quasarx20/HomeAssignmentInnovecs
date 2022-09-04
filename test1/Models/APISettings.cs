namespace test1.Models
{
    public class ApiConnections
    {
        public APISetting[]? Apisettings { get; set; }
    }
    public class APISetting
    {
        public string? ConnectionName { get; set; }
        public string? Client { get; set; }
        public string? endpoint { get; set; }
        public string? credentials { get; set; }

    }
}
