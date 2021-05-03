using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Infrastructure.Services.Interfaces
{
    public interface ITransactionManager : IService
    {
        Task<IEnumerable<UserTransaction>> BrowseUsersTransaction(Guid userId);
        Task BuyGames(Guid UserId, IDictionary<Guid,int> gameIdQuantity);        
           
    }
}