using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Game;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Api.Controllers
{
    [Route("/games")]
    public class GamesController : ApiControllerBase
    {
        private readonly IStoreBrowser _storeBrowser;        
        public GamesController(ICommandDispatcher commandDispatcher,
         IStoreBrowser storeBrowser) : base(commandDispatcher)
        {
            _storeBrowser = storeBrowser;
        }
                
        [HttpGet]
        [Route("all")]
        public async Task<IActionResult> BrowseGames([FromQuery] PaginationCommandBase command)
        {
            var results = await _storeBrowser.BrowseGamesAsync(command.PageNumber);
            return Ok(results);
        }
        [HttpGet]        
        public async Task<IActionResult> BrowseGames([FromQuery] SearchGames command)
        {
            var results = await _storeBrowser.BrowseGamesAsync(command.Term,command.MinPrice,
                command.MaxPrice,command.Platform,command.IsDigital,command.Categories,
                command.PageNumber);
            return Ok(results);
        }
        
    }
}