using System.Threading.Tasks;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Game;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Handlers.Game
{
    public class CreateGameHandler : ICommandHandler<CreateGame>
    {
        private readonly IGameManager _gameManager;
        public CreateGameHandler(IGameManager gameManager)
        {
            _gameManager = gameManager;
        }
        public async Task HandleAsync(CreateGame c)
        {
            await _gameManager.CreateGameAsync(c.Id,c.Name,c.Price,c.Quantity,c.Description,
                        c.AgeCategory,c.ReleaseDate,c.IsDigital,c.platformName,c.Categories);
        }
    }
}