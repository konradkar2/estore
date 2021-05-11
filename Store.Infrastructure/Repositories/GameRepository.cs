using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
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
        public async Task<IEnumerable<Game>> BrowseAsync(int skip, int take)       
                => await _context.Game
                            .Include(g => g.Platform)
                            .Include(g => g.GameCategories)
                            .ThenInclude(gc => gc.Category)
                            .Skip(skip).Take(take)
                            .ToListAsync();

        public async Task<IEnumerable<Game>> BrowseAsync(Expression<Func<Game,bool>> filter, int skip, int take)
        {
            return await _context.Game
                            .Include(g => g.Platform)                                
                            .Include(g => g.GameCategories)
                            .ThenInclude(gc => gc.Category)                                              
                            .Where(filter)
                            .Skip(skip).Take(take)
                            .ToListAsync();
        }
        public async Task<Game> GetAsync(Guid id)
                => await _context.Game
                            .Include(g => g.Platform)
                            .Include(g => g.GameCategories)
                            .ThenInclude(gc => gc.Category)
                            .SingleOrDefaultAsync(x => x.Id == id);
        public async Task AddAsync(Game game)
        {
            await _context.Game.AddAsync(game);         
            await _context.SaveChangesAsync();   
        }
        public async Task RemoveAsync(Guid id)
        {
            var game = await GetAsync(id);
            _context.Game.Remove(game);   
            await _context.SaveChangesAsync();            
        }        

        public async Task Update(Game game)
        {
            _context.Game.Update(game);        
            await _context.SaveChangesAsync();      
        }
       
    }
}