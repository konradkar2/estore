using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using Store.Api;

namespace Store.Tests.Integration
{
    public class APIWebApplicationFactory : WebApplicationFactory<Startup>
    {
        protected override IHostBuilder CreateHostBuilder()
    {
        return Host.CreateDefaultBuilder()
        .ConfigureWebHostDefaults(builder =>
        {
            builder.UseStartup<Startup>();
        }).
        UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
    }
}