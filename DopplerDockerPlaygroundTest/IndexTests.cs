using Microsoft.AspNetCore.Mvc.Testing;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace DopplerDockerPlaygroundTest
{
    public class IndexTests : IClassFixture<WebApplicationFactory<DopplerDockerPlayground.Startup>>
    {
        private readonly WebApplicationFactory<DopplerDockerPlayground.Startup> _factory;

        public IndexTests(WebApplicationFactory<DopplerDockerPlayground.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/")]
        public async Task Index_should_increment_ServerCounter_in_consecutive_requests(string url)
        {
            // Arrange
            var serverCounterRegex = new Regex(@"<dt>ServerCounter</dt>\s+<dd>(\d+)</dd>");
            int ExtractServerCounter(string str) =>
                int.Parse(serverCounterRegex.Match(str).Groups[1].Value);

            var client = _factory.CreateClient();

            var firstResponse = await client.GetAsync(url);
            var firstContent = await firstResponse.Content.ReadAsStringAsync();
            Assert.Matches(serverCounterRegex, firstContent);
            var firstServerCounter = ExtractServerCounter(firstContent);

            // Act
            var secondResponse = await client.GetAsync(url);

            // Assert
            var secondContent = await secondResponse.Content.ReadAsStringAsync();
            Assert.Matches(serverCounterRegex, secondContent);
            var secondServerCounter = ExtractServerCounter(secondContent);
            Assert.Equal(firstServerCounter + 1, secondServerCounter);

            // Act
            var thirdResponse = await client.GetAsync(url);

            // Assert
            var thirdContent = await thirdResponse.Content.ReadAsStringAsync();
            Assert.Matches(serverCounterRegex, thirdContent);
            var thirdServerCounter = ExtractServerCounter(thirdContent);
            Assert.Equal(firstServerCounter + 2, thirdServerCounter);
        }
    }
}
