using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace DopplerDockerPlaygroundTest
{
    public class BasicTests : IClassFixture<WebApplicationFactory<DopplerDockerPlayground.Startup>>
    {
        private readonly WebApplicationFactory<DopplerDockerPlayground.Startup> _factory;

        public BasicTests(WebApplicationFactory<DopplerDockerPlayground.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/no-existe")]
        [InlineData("/wrongPage")]
        public async Task Get_inexistent_endpoint_should_return_404_status_code(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Theory]
        [InlineData("/")]
        public async Task Get_existent_endpoint_should_return_200_status_code(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
