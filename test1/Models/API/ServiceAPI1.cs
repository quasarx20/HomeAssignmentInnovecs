using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System.Xml.Linq;

namespace test1.Models.API
{
    /// <summary>
    /// request implementation for API1
    /// </summary>
    public class ServiceAPI1 : IService
    {
        private APISetting settings;
        public IConfiguration? _configuration { get; set; }
        public ServiceAPI1(IOptions<ApiConnections> configuration)
        {
            settings = configuration?.Value?.Apisettings?.FirstOrDefault(item => GetType().Name.Equals(item.ConnectionName));
        }


        public async Task<OutputData> getData(InputData data)
        {

            try
            {
                var client = new RestClient(settings.Client);
                var request = new RestRequest(settings.endpoint, Method.Post);
                object body = new
                {
                    ContactAddress = data.SourceAddress,
                    WarehouseAdress = data.DestinationAddress,
                    packageDimesions = data.CartonDimensions
                };

                //request.AddHeader("Authorization", $"Bearer {token}");
                request.AddHeader("content-type", "application/json");
                request.AddBody(body);


                RestResponse response = await client.ExecuteAsync(request).ConfigureAwait(false);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseValue = JsonConvert.DeserializeObject<responseObject>(response.Content);
                    return new OutputData() { Company = "API1", Total = responseValue.total };
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {

                return null;
            }


        }

        public class responseObject
        {
            public int total { get; set; }
        }
    }
}
