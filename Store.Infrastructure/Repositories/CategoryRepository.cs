using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;
using Store.Core.Repositories;
using Store.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Store.Infrastructure.Repositories
{
    public class CategoryRepository : ISqlRepository,ICategoryRepository
    {
        private readonly StoreContext _context;
        public CategoryRepository(StoreContext context)
        {
            _context = context;
        }            
        public async Task<IEnumerable<Category>> BrowseAsync()
                => await _context.Category.ToListAsync();

        public async Task<Category> GetAsync(Guid id)
                => await _context.Category.SingleOrDefaultAsync(x => x.Id == id);
        public async Task<Category> GetAsync(string name)
                => await _context.Category.SingleOrDefaultAsync(x=> x.Name == name);
         public async Task AddAsync(Category category)
        {
            await _context.Category.AddAsync(category);
            await _context.SaveChangesAsync();
        }  

        public async Task RemoveAsync(Guid id)
        {
            var category = await GetAsync(id);
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }
        public async Task RemoveAsync(string name)
        {
           var category = await GetAsync(name);
            _context.Remove(category);
            await _context.SaveChangesAsync();
        }       

        public async Task Update(Category category)
        {
            _context.Update(category);
            await _context.SaveChangesAsync();
        }
    }
}