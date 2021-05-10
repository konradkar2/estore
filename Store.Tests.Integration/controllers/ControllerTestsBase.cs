using System.IO;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Configuration;
using Store.Api;
using Xunit;

namespace Store.Tests.Integration.controllers
{
    public class ControllerTestsBase : IClassFixture<CustomWebApplicationFactory<Startup>> 
    {
        protected readonly WebApplicationFactory<Startup> Factory;
        protected readonly HttpClient Client;
        public ControllerTestsBase(CustomWebApplicationFactory<Startup> factory)
        {                     
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.json");

         
            Factory = factory.WithWebHostBuilder(builder =>
            {
                builder.ConfigureAppConfiguration((context,conf) =>
                {
                    conf.AddJsonFile(configPath);
                });

            });
            Client = Factory.CreateClient();
        }
    }
}