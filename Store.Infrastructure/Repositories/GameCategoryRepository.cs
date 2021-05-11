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
    public class GameCategoryRepository : ISqlRepository,IGameCategoryRepository
    {
        private readonly StoreContext _context;
        public GameCategoryRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<GameCategory>> GetManyAsync(Guid gameId)
                => await _context.GameCategory.Where(x => x.GameId == gameId).ToListAsync();
        public async Task AddAsync(GameCategory gameCategory)
        {
            await _context.GameCategory.AddAsync(gameCategory);
            await _context.SaveChangesAsync();
        }       
        public async Task RemoveAsync(Guid id)
        {
            var GameCategory = await _context.GameCategory.SingleOrDefaultAsync(x => x.Id == id);
            _context.GameCategory.Remove(GameCategory);
            await _context.SaveChangesAsync();
        }       

        public async Task Update(GameCategory gameCategory)
        {
            _context.GameCategory.Update(gameCategory);
            await _context.SaveChangesAsync();
        }
    }
}