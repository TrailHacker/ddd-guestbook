using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using CleanArchitecture.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

namespace CleanArchitecture.Tests.Integration.Web
{
    public class TestServerFixture : IDisposable
    {
		public TestServer Server { get; }
		public HttpClient Client { get; }

	    public TestServerFixture()
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

	    }

	    public void Dispose()
	    {
		    
	    }
    }
}
