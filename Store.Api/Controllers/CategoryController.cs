using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Category;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Api.Controllers
{
    public class CategoryController: ApiControllerBase
    {
        private readonly IGameManager _gameManager;
        public CategoryController(ICommandDispatcher commandDispatcher,
         IGameManager gameManager) : base(commandDispatcher)
        {
            _gameManager = gameManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateGamePost([FromBody] CreateCategory command)
        {
            command.Id = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}