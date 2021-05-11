using System;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface IGameTransactionRepository : IRepository
    {        
        Task<GameTransaction> GetAsync(Guid Id);        
        Task AddAsync(GameTransaction gameTransaction);
        Task Update(GameTransaction gameTransaction);  //not sure if should be async, but if 
        Task RemoveAsync(Guid id);  
    }
}