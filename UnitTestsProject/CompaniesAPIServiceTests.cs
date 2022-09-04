using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using test1.BLL.Interfaces;
using test1.BLL.Service;

namespace RestsharpTests
{
    [TestFixture]
    class CompaniesAPIServiceTests
    {
        private IOptions<ApiConnections> options;

        [OneTimeSetUp]
        public void GlobalSetup()
        {
            List<APISetting> Apisettings = new List<APISetting>();
            Apisettings.Add(new APISetting 
            { ConnectionName = "ServiceAPI1", Client = "https://localhost:7206", endpoint = "/CompanyAPI/GetAPI1" });
            Apisettings.Add(new APISetting
            { ConnectionName = "ServiceAPI2", Client = "https://localhost:7206", endpoint = "/CompanyAPI/GetAPI2" });
            Apisettings.Add(new APISetting
            { ConnectionName = "ServiceAPI3", Client = "https://localhost:7206", endpoint = "/CompanyAPI/GetAPI3" });
            this.options = Options.Create<ApiConnections>(new ApiConnections()
            {
                Apisettings = Apisettings.ToArray()
            });
        }



        [Test]
        public async Task CompaniesAPIServiceTestsShould()
        {
            //Arrange           
            CompaniesAPIService companiesAPI = new CompaniesAPIService(null);

            //Act
            var result = await companiesAPI.getQuotes(new InputData(), options);

            //Assert
            Assert.IsTrue(result == null);
        }
    }
}

