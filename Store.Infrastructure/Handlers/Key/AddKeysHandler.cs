using System.Threading.Tasks;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Key;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Handlers.Key
{
    public class AddKeysHandler : ICommandHandler<AddKeys>
    {
        private readonly IKeyManager _keyManager;
        public AddKeysHandler(IKeyManager keyManager)
        {
            _keyManager = keyManager;
        }
        public async Task HandleAsync(AddKeys command)
        {
            await _keyManager.AddKeysAsync(command.GameId, command.Keys);
        }
    }
}