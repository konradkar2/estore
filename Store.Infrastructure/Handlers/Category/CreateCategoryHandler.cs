using System.Threading.Tasks;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Category;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Handlers.Category
{
    public class CreateCategoryHandler : ICommandHandler<CreateCategory>
    {
        private readonly IGameManager _gameManager;
        public CreateCategoryHandler(IGameManager gameManager)
        {
            _gameManager = gameManager;            
        }
        public async Task HandleAsync(CreateCategory command)
        {
            await _gameManager.CreateCategoryAsync(command.Id,command.Name);
        }
    }
}