using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface IGameRepository
    {
         Task<Platform> GetAsync(Guid id);
         Task<IEnumerable<Platform>> BrowseAsync(int offset, int limit);
         Task AddAsync(Platform game);
         Task UpdateAsync(Platform game);
         Task RemoveAsync(Platform game);
    }
}