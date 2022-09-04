using Microsoft.Extensions.Options;
using test1.Models;

namespace test1.BLL.Interfaces
{
    public interface ICompaniesAPIService
    {
        public Task<OutputData> getQuotes(InputData data, IOptions<ApiConnections> configuration);
    }
}
