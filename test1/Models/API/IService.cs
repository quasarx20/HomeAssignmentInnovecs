using RestSharp;
namespace test1.Models.API
{
    /// <summary>
    /// service interface
    /// </summary>
    public interface IService
    {
        public IConfiguration _configuration { get; }
        public Task<OutputData> getData(InputData data);
       
    }
}
