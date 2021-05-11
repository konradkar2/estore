using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Queries;
using Store.Infrastructure.Queries.Game;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Api.Controllers
{
    [Route("games")]
    public class GameBrowseController : ApiControllerBase
    {
        private readonly IStoreBrowser _storeBrowser;        
        public GameBrowseController(ICommandDispatcher commandDispatcher,
         IStoreBrowser storeBrowser) : base(commandDispatcher)
        {
            _storeBrowser = storeBrowser;
        }                
        
        [HttpGet]  
        [Route("all/{page}")]  
        public async Task<IActionResult> BrowseGames(int page,[FromQuery] SearchGames query)
        {            
            query.Page = page;
            var results = await _storeBrowser.BrowseGamesAsync(query.Term,query.MinPrice,
                query.MaxPrice,query.Platform,query.IsDigital,query.Categories,
                query.Page);
            return Ok(results);
        }
        [HttpGet]  
        [Route("{gameId}")]  
        public async Task<IActionResult> Get(Guid gameId)
        {           
           
            var result = await _storeBrowser.GetAsync(gameId);               
            return Ok(result);
        }
        
    }
}