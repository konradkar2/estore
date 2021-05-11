using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Core.Domain;
using Store.Core.Repositories;
using Store.Infrastructure.EF;

namespace Store.Infrastructure.Repositories
{
    public class GameTransactionRepository : ISqlRepository, IGameTransactionRepository
    {
        private readonly StoreContext _context;
        public GameTransactionRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<GameTransaction> GetAsync(Guid id)
                => await _context.GameTransaction.SingleOrDefaultAsync(x => x.Id == id);
        public async Task AddAsync(GameTransaction gameTransaction)
        {
            await _context.GameTransaction.AddAsync(gameTransaction);
            await _context.SaveChangesAsync();   
        }        

        public async Task RemoveAsync(Guid id)
        {
            var gt = await GetAsync(id);
            _context.GameTransaction.Remove(gt);
            await _context.SaveChangesAsync();   
        }

        public async Task Update(GameTransaction gameTransaction)
        {
            _context.GameTransaction.Update(gameTransaction);
            await _context.SaveChangesAsync();   
        }
    }
}