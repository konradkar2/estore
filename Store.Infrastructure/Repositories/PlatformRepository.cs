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
    public class PlatformRepository : ISqlRepository, IPlatformRepository
    {
        private readonly StoreContext _context;
        public PlatformRepository(StoreContext context)
        {
            _context = context;
        }        

        public async Task<IEnumerable<Platform>> BrowseAsync()
                => await _context.Platform.ToListAsync();

        public async Task<Platform> GetAsync(Guid id)
                => await _context.Platform.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Platform> GetAsync(string name)
                => await _context.Platform.SingleOrDefaultAsync(x => x.Name == name);
        public async Task AddAsync(Platform platform)
        {
            await _context.Platform.AddAsync(platform);            
        }
        public async Task RemoveAsync(Guid id)
        {
            var platform = await GetAsync(id);
            _context.Platform.Remove(platform);  
            await _context.SaveChangesAsync();          
        }

        public async Task Update(Platform platform)
        {
            _context.Platform.Update(platform);    
            await _context.SaveChangesAsync(); 
        }        
        
    }
}