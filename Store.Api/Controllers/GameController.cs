using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Game;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Api.Controllers
{
    public class GameController : ApiControllerBase
    {
        private readonly IStoreManager _storeManager;
        public GameController(ICommandDispatcher commandDispatcher,
         IStoreManager storeManager) : base(commandDispatcher)
        {
            _storeManager = storeManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateGamePost([FromBody] CreateGame command)
        {
            command.Id = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
        [HttpGet]
        public async Task<IActionResult> BrowseGames()
        {
            var results = await _storeManager.BrowseAsync();
            return Ok(results);
        }
    }
}