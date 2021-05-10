using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Key;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Api.Controllers
{
    public class KeyController : ApiControllerBase
    {
        private readonly IKeyBrowser _keyBrowser;
        public KeyController(ICommandDispatcher commandDispatcher,
         IKeyBrowser keyBrowser ): base(commandDispatcher)
        {
            _keyBrowser = keyBrowser;
        }
        [HttpPost]
        public async Task<IActionResult> AddKeys([FromBody] AddKeys command)
        {            
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
        [HttpGet("gameId")]
        public async Task<IActionResult> Get(Guid gameId)
        {
            var results = await _keyBrowser.BrowseKeysAsync(gameId);
            return Ok(results);
        }
    }
}