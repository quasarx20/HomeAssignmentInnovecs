using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using test1.BLL.Interfaces;
using test1.BLL.Service;
using test1.Models;
using test1.Utilities;

namespace test1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OffersController : BaseResponse
    {
       

        private readonly ILogger<OffersController> _logger;
        private readonly ICompaniesAPIService companiesAPIService;
        private readonly IOptions<ApiConnections> configuration;

        public OffersController(ILogger<OffersController> logger, ICompaniesAPIService companiesAPIService, IOptions<ApiConnections> configuration)
        {
            _logger = logger;
            this.companiesAPIService = companiesAPIService;
            this.configuration = configuration;
        }

        [HttpPost(Name = "GetBestOffer")]
        public async Task<IActionResult> Post(InputData input)
        {
            try
            {
            return Ok(await companiesAPIService.getQuotes(input, configuration));

            }
            catch (Exception e)
            {

                return Error(e.Message);
            }
        }
    }
}