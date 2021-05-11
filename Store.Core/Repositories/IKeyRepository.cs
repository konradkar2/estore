using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface IKeyRepository : IRepository
    {
        //get key by its primary key
        Task<Key> GetAsync(Guid id);        
        Task<IEnumerable<Key>> TakeNotUsedAsync(Guid gameId, int quantity);
        //this function is used to check if any of provided keys already exists
        Task<IEnumerable<Key>> BrowseAsync(Guid gameId, IEnumerable<string> keys);
        Task<IEnumerable<Key>> BrowseAsync(Guid gameId);
        Task<int> GetNotUsedCountAsync(Guid gameId);
        Task AddAsync(Key key);
        Task AddManyAsync(IEnumerable<Key> keys);
        Task Update(Key key);
        Task RemoveAsync(Guid id);         
    }
}