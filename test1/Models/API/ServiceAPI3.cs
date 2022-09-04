using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using RestSharp.Serializers.Xml;

namespace test1.Models.API
{
    /// <summary>
    /// request implementation for API3
    /// </summary>
    public class ServiceAPI3 : IService
    {
        private APISetting settings;
        public IConfiguration? _configuration { get; set; }
        public ServiceAPI3(IOptions<ApiConnections> configuration)
        {
            settings = configuration?.Value?.Apisettings?.FirstOrDefault(item => GetType().Name.Equals(item.ConnectionName));
        }


        public async Task<OutputData> getData(InputData data)
        {

            try
            {
                var client = new RestClient(settings.Client);
                client.UseXmlSerializer();
                var request = new RestRequest(settings.endpoint, Method.Post);
                object body = new
                {
                    API3Input = new
                    {
                        source = data.SourceAddress,
                        destination = data.DestinationAddress,
                        packages = data.CartonDimensions
                    }
                };
                request.AddBody(body);
                RestResponse response = await client.ExecuteAsync(request).ConfigureAwait(false);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {

                    var dotNetXmlDeserializer = new DotNetXmlDeserializer();
                    API3Output modelClassObject = dotNetXmlDeserializer.Deserialize<API3Output>(response);
                    return new OutputData() { Company = "API3", Total = modelClassObject.quote };
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

        public class API3Output
        {

            public int quote { get; set; }
        }
    }
}

