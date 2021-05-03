using System.Threading.Tasks;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Key;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Handlers.Key
{
    public class AddKeysHandler : ICommandHandler<AddKeys>
    {
        private readonly IStoreManager _storeManager;
        public AddKeysHandler(IStoreManager storeManager)
        {
            _storeManager = storeManager;
        }
        public async Task HandleAsync(AddKeys command)
        {
            await _storeManager.AddKeysAsync(command.GameId, command.Keys);
        }
    }
}