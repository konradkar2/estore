using System.IO;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Store.Api;

namespace Store.Tests.Integration
{
   public class CustomWebApplicationFactory<TStartup>
    : WebApplicationFactory<TStartup> where TStartup: class
    {
        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
            .ConfigureWebHostDefaults(builder =>
            {
                builder.UseStartup<TStartup>();
            })
            .UseServiceProviderFactory(new AutofacServiceProviderFactory());
        }
    }
}