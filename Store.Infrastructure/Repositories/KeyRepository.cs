using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Core.Domain;
using Store.Core.Repositories;
using Store.Infrastructure.EF;

namespace Store.Infrastructure.Repositories
{
    public class KeyRepository : ISqlRepository, IKeyRepository
    {
        private readonly StoreContext _context;
        public KeyRepository(StoreContext context)
        {
            _context = context;
        }       

        public async Task<IEnumerable<Key>> BrowseAsync(Guid gameId)
                => await  _context.Key
                        .Include(k => k.Game)
                        .Where(k => k.GameId == gameId).ToListAsync();                                      
        public async Task<Key> GetAsync(Guid id)
                => await  _context.Key.SingleOrDefaultAsync(k => k.Id == id);

        public async Task<IEnumerable<Key>> BrowseAsync(Guid gameId, IEnumerable<string> keys)
                => await _context.Key
                        .Where(k => k.GameId == gameId)
                        .Where(k => keys.Any(ke => ke == k.GKey))
                        .ToListAsync();
        public async Task<int> GetNotUsedCountAsync(Guid gameId)
            => await _context.Key                                             
                        .Where(k => k.GameId == gameId)
                        .Where(k => k.Used == false)
                        .CountAsync();
       
        public async Task<IEnumerable<Key>> TakeNotUsedAsync(Guid gameId, int quantity)
            => await _context.Key     
                            .AsNoTracking()                        
                            .Where(k => k.GameId == gameId)
                            .Where(k => k.Used == false)
                            .Take(quantity)
                            .ToListAsync();
         public async Task AddAsync(Key key)        
        {           
            await _context.AddAsync(key);
            await _context.SaveChangesAsync();
        }
        public async Task AddManyAsync(IEnumerable<Key> keys)
        {
            await _context.AddRangeAsync(keys);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid id)
        {
            var key = await GetAsync(id);
             _context.Key.Remove(key);
             await _context.SaveChangesAsync();   
        }       

        public async Task Update(Key key)
        {
            _context.Key.Update(key);
            await _context.SaveChangesAsync();   
        }
        
    }
}