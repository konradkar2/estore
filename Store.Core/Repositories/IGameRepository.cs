using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface IGameRepository : IRepository
    {
         Task<Key> GetAsync(Guid id);
         Task<IEnumerable<Key>> BrowseAsync();
         Task AddAsync(Key game);
         Task UpdateAsync(Key game);
         Task RemoveAsync(Guid id);
    }
}