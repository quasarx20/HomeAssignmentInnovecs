using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;

namespace test1.Models.API
{
    /// <summary>
    /// request implementation for API2
    /// </summary>
    public class ServiceAPI2 : IService
    {
        private APISetting settings;
        public IConfiguration? _configuration { get; set; }
        public ServiceAPI2(IOptions<ApiConnections> configuration)
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
                    Consignee = data.SourceAddress,
                    Consignor = data.DestinationAddress,
                    cartons = data.CartonDimensions
                };
                //request.AddHeader("Authorization", $"Bearer {token}");
                request.AddHeader("content-type", "application/json");
                request.AddBody(body);

                RestResponse response = await client.ExecuteAsync(request).ConfigureAwait(false);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    var responseValue = JsonConvert.DeserializeObject<responseObject>(response.Content);
                    return new OutputData() { Company = "API2", Total = responseValue.amount };
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

        private class responseObject
        {
            public int amount { get; set; }
        }
    }
}

