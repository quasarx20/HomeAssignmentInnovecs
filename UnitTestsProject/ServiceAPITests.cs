namespace RestsharpTests
{
    [TestFixture]
    public class ServiceAPITests
    {

        
        [Test]
        public async Task ServiceAPI1ShouldFail()
        {

            //Arrange
            List<APISetting> Apisettings = new List<APISetting>();
            Apisettings.Add(new APISetting { ConnectionName = "ServiceAPI1", Client = "https://localhost:7206", endpoint = "/CompanyAPI/GetAPI1" });
            IOptions<ApiConnections> someOptions = Options.Create<ApiConnections>(new ApiConnections()
            {
                Apisettings = Apisettings.ToArray()
            }) ;
            ServiceAPI1 api = new ServiceAPI1(someOptions);

            //Act
            var user = await api.getData(new InputData());
            
            //Assert
            
            //this is null because the dummy service is not running
            Assert.True(user == null);    
        }

        [Test]
        [Ignore("Ignored")]
        public async Task ServiceAPI1Should()
        {

            //Arrange
            List<APISetting> Apisettings = new List<APISetting>();
            Apisettings.Add(new APISetting { ConnectionName = "ServiceAPI1", Client = "https://localhost:7206", endpoint = "/CompanyAPI/GetAPI1" });
            IOptions<ApiConnections> someOptions = Options.Create<ApiConnections>(new ApiConnections()
            {
                Apisettings = Apisettings.ToArray()
            });
            ServiceAPI1 api = new ServiceAPI1(someOptions);

            //Act
            var user = await api.getData(new InputData() {  });
            //Assert

            Assert.True(user != null);
            //if dummy service is running, should response a value
            Assert.True(user.Total >= 0);
        }
    }
}