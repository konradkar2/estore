using System;
using System.Threading.Tasks;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Platform;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Handlers.Platform
{
    public class CreatePlatformHandler: ICommandHandler<CreatePlatform>
    {
        private readonly IPlatformService _platformService;
        public CreatePlatformHandler(IPlatformService platformService){
            _platformService = platformService;
        }
        public async Task HandleAsync(CreatePlatform command)
        {                        
            await _platformService.CreateAsync(command.Id,command.Name);
        }
    }
}