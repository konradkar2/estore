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
        private readonly IKeyManager _keyManager;
        public KeyController(ICommandDispatcher commandDispatcher,
         IKeyManager StoreManager) : base(commandDispatcher)
        {
            _keyManager = StoreManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategoryPost([FromBody] AddKeys command)
        {            
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
        [HttpGet("gameId")]
        public async Task<IActionResult> Get(Guid gameId)
        {
            var results = await _keyManager.BrowseKeysAsync(gameId);
            return Ok(results);
        }
    }
}