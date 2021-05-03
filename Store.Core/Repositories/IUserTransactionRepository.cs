using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface IUserTransactionRepository : IRepository
    {
        Task<IEnumerable<UserTransaction>> GetManyAsync(Guid userId);
        Task<UserTransaction> GetAsync(Guid id);
        Task<IEnumerable<UserTransaction>> BrowseAsync(int offset, int limit);
        Task AddAsync(UserTransaction userTransaction);
        void Update(UserTransaction userTransaction);  //not sure if should be async, but if 
        Task RemoveAsync(Guid id);  
    }
}