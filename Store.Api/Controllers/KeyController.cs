using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Key;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Api.Controllers
{
    public class KeyController : ApiControllerBase
    {
        private readonly IStoreManager _StoreManager;
        public KeyController(ICommandDispatcher commandDispatcher,
         IStoreManager StoreManager) : base(commandDispatcher)
        {
            _StoreManager = StoreManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategoryPost([FromBody] AddKeys command)
        {            
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}