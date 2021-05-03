using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Store.Core.Domain;
using Store.Core.Repositories;
using Store.Infrastructure.EF;

namespace Store.Infrastructure.Repositories
{
    public class GameRepository : ISqlRepository, IGameRepository
    {
        private readonly StoreContext _context;
        public GameRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Game game)
        {
            await _context.Game.AddAsync(game);            
        }

        
        public async Task<IEnumerable<Game>> BrowseAsync()       
                => await _context.Game
                            .Include(g => g.Platform)
                            .Include(g => g.GameCategories)
                            .ThenInclude(gc => gc.Category)
                            .ToListAsync();
        

        public async Task<Game> GetAsync(Guid id)
                => await _context.Game
                            .Include(g => g.Platform)
                            .Include(g => g.GameCategories)
                            .ThenInclude(gc => gc.Category)
                            .SingleOrDefaultAsync(x => x.Id == id);

        public async Task RemoveAsync(Guid id)
        {
            var game = await GetAsync(id);
            _context.Game.Remove(game);            
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(Game game)
        {
            _context.Game.Update(game);           
        }
       
    }
}