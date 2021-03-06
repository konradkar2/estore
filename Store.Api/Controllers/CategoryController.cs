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
        private readonly IStoreManager _StoreManager;
        public CategoryController(ICommandDispatcher commandDispatcher,
         IStoreManager StoreManager) : base(commandDispatcher)
        {
            _StoreManager = StoreManager;
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategoryPost([FromBody] CreateCategory command)
        {
            command.Id = Guid.NewGuid();
            await CommandDispatcher.DispatchAsync(command);
            return NoContent();
        }
    }
}