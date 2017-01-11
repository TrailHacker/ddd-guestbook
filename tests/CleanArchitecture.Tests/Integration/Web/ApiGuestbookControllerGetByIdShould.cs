using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using CleanArchitecture.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Xunit;

namespace CleanArchitecture.Tests.Integration.Web
{
	public class ApiGuestbookControllerGetByIdShould : IClassFixture<TestServerFixture>
	{
		private readonly HttpClient _client;

		protected HttpClient GetClient()
		{
			var builder = new WebHostBuilder()
				.UseContentRoot(Directory.GetCurrentDirectory())
				.UseStartup<Startup>()
				.UseEnvironment("Testing"); // ensure ConfigureTesting is called in Startup

			var server = new TestServer(builder);
			var client = server.CreateClient();

			// client always expects json results
			client.DefaultRequestHeaders.Clear();
			client.DefaultRequestHeaders.Accept.Add(
				new MediaTypeWithQualityHeaderValue("application/json"));

			return client;
		}

		[Fact]
		public void Return404()
		{
			
		}

		[Fact]
		public void ReturnGuestbookWithEntries()
		{
			
		}
	}
}