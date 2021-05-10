using System.Threading.Tasks;

namespace Store.Infrastructure.Commands
{
    public class TransactionalCommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandDispatcher _dispatcher;
        public TransactionalCommandDispatcher(ICommandDispatcher dispatcher){
            _dispatcher = dispatcher;
        }
        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            // TODO: using(transaction){
             await _dispatcher.DispatchAsync(command);

             //}
        }
    }
}