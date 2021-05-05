using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Services.Interfaces
{
    public interface ITransactionManager : IService
    {
        Task<IEnumerable<UserTransactionDto>> BrowseUsersTransaction(Guid userId);
        Task BuyGames(Guid UserId, IDictionary<Guid,int> gameIdQuantity);        
           
    }
}