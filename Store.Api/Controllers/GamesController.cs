using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Queries;
using Store.Infrastructure.Queries.Game;
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
        public async Task<IActionResult> BrowseGames([FromQuery] PaginationQueryBase query)
        {
            var results = await _storeBrowser.BrowseGamesAsync(query.PageNumber);
            return Ok(results);
        }
        [HttpGet]        
        public async Task<IActionResult> BrowseGames([FromQuery] SearchGames query)
        {
            var results = await _storeBrowser.BrowseGamesAsync(query.Term,query.MinPrice,
                query.MaxPrice,query.Platform,query.IsDigital,query.Categories,
                query.PageNumber);
            return Ok(results);
        }
        
    }
}