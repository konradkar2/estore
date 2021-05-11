using System.Data;
using System.Threading.Tasks;
using Store.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
namespace Store.Infrastructure.Commands
{
    public class TransactionalCommandDispatcher : ICommandDispatcher
    {
        private readonly ICommandDispatcher _dispatcher;
        private readonly StoreContext _context;
        public TransactionalCommandDispatcher(ICommandDispatcher dispatcher, StoreContext context)
        {
            _dispatcher = dispatcher;
            _context = context;
        }
        public async Task DispatchAsync<T>(T command) where T : ICommand
        {
            using (var transaction = await _context.Database.BeginTransactionAsync(IsolationLevel.Serializable))
            {
                try{
                    await _dispatcher.DispatchAsync(command);
                    await transaction.CommitAsync();
                }
                catch
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
            

            
        }
    }
}