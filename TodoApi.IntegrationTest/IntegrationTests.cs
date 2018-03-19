using System.Net.Http;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace TodoApi.IntegrationTest
{
    [TestClass]
    public class AddATodoItem
    {
        private TestServer _server;
        private HttpClient _client;


        public AddATodoItem()
        {
            // Arrange
            _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
            _client = _server.CreateClient();
        }

        [TestMethod]
        public async void GetAll_OK()
        {

            // Act 
            var response = await _client.GetAsync("/");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual("hello", responseString);
        }
    }
}
