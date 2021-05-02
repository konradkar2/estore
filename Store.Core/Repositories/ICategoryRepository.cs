using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface ICategoryRepository : IRepository
    {
        Task<Category> GetAsync(Guid id);         
        Task<Category> GetAsync(string name);         
        Task<IEnumerable<Category>> BrowseAsync();         
         Task AddAsync(Category category);
         void Update(Category category);
         Task RemoveAsync(Guid id);
         Task RemoveAsync(string name);
    }
}