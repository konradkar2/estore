using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Services.Interfaces
{
    public interface IKeyManager
    {
        Task AddKeysAsync(Guid gameId,IEnumerable<string> keys);     
        Task<IEnumerable<KeyDto>> BrowseKeysAsync(Guid gameId);    
        Task<int> GetNotUsedKeyCount(Guid gameId);
    }
}