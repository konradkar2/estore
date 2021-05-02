using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;
namespace Store.Core.Repositories
{
    public interface IGameCategoryRepository
    {
         Task<GameCategory> GetAsync(Guid id);
         Task<IEnumerable<GameCategory>> BrowseAsync(int offset, int limit);
         Task AddAsync(GameCategory gameCategory);
         Task UpdateAsync(GameCategory gameCategory);
         Task RemoveAsync(GameCategory gameCategory);
    }
}