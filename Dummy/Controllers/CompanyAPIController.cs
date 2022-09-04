using Dummy.Models;
using Dummy.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace Dummy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [FormatFilter]
    public class CompanyAPIController : ControllerBase
    {

        private readonly ILogger<CompanyAPIController> _logger;

        public CompanyAPIController(ILogger<CompanyAPIController> logger)
        {
            _logger = logger;
        }

        [HttpPost("GetAPI1")]
        public API1Output Get1(API1Input input) => new() { Total = Random.Shared.Next(100, 1000)};
        

        [HttpPost("GetAPI2")]
        public API2Output Get2(API2Input input) => new() { amount = Random.Shared.Next(100, 1000) };
        

        [HttpPost("{GetAPI3}.{format?}")]
        public API3Output Get3(API3Input input) => ( new () { quote = Random.Shared.Next(100, 1000) });

    }
}