using System.Threading.Tasks;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Game;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Handlers.Game
{
    public class CreateGameHandler : ICommandHandler<CreateGame>
    {
        private readonly IStoreManager _storeManager;
        public CreateGameHandler(IStoreManager storeManager)
        {
            _storeManager = storeManager;
        }
        public async Task HandleAsync(CreateGame c)
        {
            await _storeManager.CreateGameAsync(c.Id,c.Name,c.Price,c.Quantity,c.Description,
                        c.AgeCategory,c.ReleaseDate,c.IsDigital,c.platformName,c.Categories);
        }
    }
}