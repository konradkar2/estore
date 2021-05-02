using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;
namespace Store.Core.Repositories
{
    public interface IGameCategoryRepository : IRepository
    {
         Task<IEnumerable<GameCategory>> GetManyAsync(Guid gameId);         
         Task AddAsync(GameCategory gameCategory);
         void Update(GameCategory gameCategory);
         Task RemoveAsync(Guid id);
    }
}