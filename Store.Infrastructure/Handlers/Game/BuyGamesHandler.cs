using System.Threading.Tasks;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Game;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Handlers.Game
{
    public class BuyGamesHandler : ICommandHandler<BuyGames>
    {
        private readonly ITransactionManager _transactionManager;
        public BuyGamesHandler(ITransactionManager transactionManager)
        {
            _transactionManager = transactionManager;
        }
        public async Task HandleAsync(BuyGames command)
        {
            await _transactionManager.BuyGames(command.UserId,command.Cart);
        }
    }
}