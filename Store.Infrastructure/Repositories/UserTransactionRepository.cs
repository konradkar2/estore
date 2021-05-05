using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Core.Domain;
using Store.Core.Repositories;
using Store.Infrastructure.EF;

namespace Store.Infrastructure.Repositories
{
    public class UserTransactionRepository : ISqlRepository, IUserTransactionRepository
    {
        private readonly StoreContext _context;
        public UserTransactionRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task AddAsync(UserTransaction userTransaction)
        {
            await _context.UserTransaction.AddAsync(userTransaction);
        }

        public async Task<IEnumerable<UserTransaction>> BrowseAsync(int offset, int limit)
                => await _context.UserTransaction
                            .Include(ut => ut.GameTransactions)
                            .Skip(limit).Take(offset).ToListAsync();
        

        public async Task<UserTransaction> GetAsync(Guid id)
                => await _context.UserTransaction
                            .Include(ut => ut.GameTransactions)
                            .SingleOrDefaultAsync(x => x.Id == id);
        public async Task<IEnumerable<UserTransaction>> GetManyAsync(Guid userId)
                => await _context.UserTransaction
                                    .Include(ut => ut.GameTransactions)   
                                        .ThenInclude(gt => gt.Key)
                                    .Include(ut => ut.GameTransactions)
                                        .ThenInclude(gt => gt.Game)
                                            .ThenInclude(g => g.GameCategories)
                                                .ThenInclude(gc => gc.Category)   
                                    .Include(ut => ut.GameTransactions)
                                        .ThenInclude(gt => gt.Game)
                                            .ThenInclude(g => g.Platform)                                                                                 
                                    .Where(ut => ut.UserId == userId)                                    
                                    .ToListAsync();

        public async Task RemoveAsync(Guid id)
        {
            var ut = await GetAsync(id);
            _context.UserTransaction.Remove(ut);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(UserTransaction userTransaction)
        {
            _context.UserTransaction.Update(userTransaction);
        }
    }
}