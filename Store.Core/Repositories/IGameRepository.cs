using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface IGameRepository : IRepository
    {
         Task<Game> GetAsync(Guid id);
         Task<IEnumerable<Game>> BrowseAsync(int skip, int take);
         Task<IEnumerable<Game>> BrowseAsync(Expression<Func<Game,bool>> filter, int skip,int take);
         Task AddAsync(Game game);
         void Update(Game game);
         Task RemoveAsync(Guid id);
    }
}