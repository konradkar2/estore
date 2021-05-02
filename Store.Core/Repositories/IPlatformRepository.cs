using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface IPlatformRepository : IRepository
    {
        Task<Key> GetAsync(Guid id);
         Task<IEnumerable<Key>> BrowseAsync();
         Task AddAsync(Key platform);
         Task UpdateAsync(Key platform);
         Task RemoveAsync(Key platform);    
    }
}