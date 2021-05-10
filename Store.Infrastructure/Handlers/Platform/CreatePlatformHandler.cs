using System;
using System.Threading.Tasks;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Platform;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Handlers.Platform
{
    public class CreatePlatformHandler: ICommandHandler<CreatePlatform>
    {
        private readonly IPlatformManager _platformManager;
        public CreatePlatformHandler(IPlatformManager platformManager){
            _platformManager = platformManager;
        }
        public async Task HandleAsync(CreatePlatform command)
        {                        
            await _platformManager.CreateAsync(command.Id,command.Name);
        }
    }
}