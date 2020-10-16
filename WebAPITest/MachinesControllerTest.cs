using Microsoft.AspNetCore.Mvc.Testing;
using System.Net.Http;
using System.Threading.Tasks;
using WebAPI;
using Xunit;

namespace WebAPITest
{
    [Collection("Integration Tests")]
    public class MachinesControllerTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly HttpClient _httpClient;

        public MachinesControllerTest(WebApplicationFactory<Startup> factory)
        {
            _httpClient = factory.CreateDefaultClient();
        }

        [Fact]
         public async Task Get_AllMachines_ReturnsSuccessStatusCode()
         {
            var response = await _httpClient.GetAsync("/api/machines");

            response.EnsureSuccessStatusCode();
         }


        [Fact]
        public async Task Get_Machine_ReturnsSuccessStatusCode()
        {
            var response = await _httpClient.GetAsync("/api/machines/machine/1");

            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task Get_TotalProduction_ReturnsSuccessStatusCode()
        {
            var response = await _httpClient.GetAsync("/api/machines/machine/totalproduction/1");

            response.EnsureSuccessStatusCode();
        }


        [Fact]
        public async Task Get_Delete_ReturnsSuccessStatusCode()
        {
            var response = await _httpClient.DeleteAsync("/api/machines/machine/1");

            response.EnsureSuccessStatusCode();
        }
    }
}