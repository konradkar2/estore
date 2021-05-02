using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Platform;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Api.Controllers
{
    public class PlatformController: ApiControllerBase
    {
        private readonly IPlatformService _platformService;
        public PlatformController(ICommandDispatcher commandDispatcher,
                IPlatformService platformService) : base(commandDispatcher)
        {
               _platformService = platformService;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreatePlatform command)
        {
            command.Id = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);

            return Created($"platforms/{command.Id}",null);            
        }
        [HttpGet]
        public async Task<IActionResult> Browse()
        {
            var platforms =  await _platformService.BrowseAsync();
            return Ok(platforms);
        }
    }
}
    