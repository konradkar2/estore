using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Game;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Api.Controllers
{
    [Route("/games/shop")]
    public class GameShopController : ApiControllerBase
    {        
        private readonly ITransactionManager _transactionManager;
        public GameShopController(ICommandDispatcher commandDispatcher,
         ITransactionManager transactionManager) : base(commandDispatcher)
        {           
            _transactionManager = transactionManager;
        }        
        [HttpPost]
        public async Task<IActionResult> BuyGames([FromBody] BuyGames command)
        {
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
        
    }
}