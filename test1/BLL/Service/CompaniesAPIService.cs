using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using test1.BLL.Interfaces;
using test1.Controllers;
using test1.Models;
using test1.Models.API;

namespace test1.BLL.Service
{
    public class CompaniesAPIService : ICompaniesAPIService
    {
        private readonly ILogger<OffersController> _logger;
        public CompaniesAPIService(ILogger<OffersController> logger)
        {
            _logger = logger;

        }

        /// <summary>
        ///  get all quotes from all IService implementations
        /// </summary>
        /// <param name="data"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        public async Task<OutputData> getQuotes(InputData data, IOptions<ApiConnections> configuration)
        {
            //get all clases that implemented IService
            var handlers = AppDomain.CurrentDomain.GetAssemblies()
           .SelectMany(s => s.GetTypes())
           .Where(p => typeof(IService).IsAssignableFrom(p) && p.IsClass);
            List<Task<OutputData>> list = new List<Task<OutputData>>();

            foreach (var handler in handlers)
            {
                //create Instance
                IService? handlerInstance = (IService)Activator.CreateInstance(handler, configuration);
                //run method
                 list.Add(handlerInstance?.getData(data));
                
            }
            //wait for all
            await Task.WhenAll(list);
            //select the first
            List<OutputData> result = list.Count > 0 ? list.Where(x => x.Result != null).Select(x => x.Result).ToList().OrderBy(x => x.Total).ToList(): throw(new Exception("No api responded"));

            return result.FirstOrDefault();
           

        }

      
    }
}
