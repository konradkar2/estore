using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface KeyRepository : IRepository
    {
        Task<Key> GetAsync(Guid id);
        Task<IEnumerable<Key>> BrowseAsync(int offset, int limit);
        Task AddAsync(Key key);
        void Update(Key key);
        Task RemoveAsync(Guid id);         
    }
}