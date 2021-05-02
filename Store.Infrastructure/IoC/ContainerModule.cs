using Autofac;
using Microsoft.Extensions.Configuration;
using Store.Infrastructure.IoC.Modules;
using Store.Infrastructure.Mappers;

namespace Store.Infrastructure.IoC
{
    public class ContainerModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;
        public ContainerModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(AutoMapperConfig.Initialize())
                .SingleInstance();

            
            builder.RegisterModule<CommandModule>();                      
            builder.RegisterModule<SqlModule>();
            builder.RegisterModule<ServiceModule>();
            builder.RegisterModule(new SettingsModule(_configuration));
        }
 
    }
}