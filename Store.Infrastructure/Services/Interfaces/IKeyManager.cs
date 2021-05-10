using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Services.Interfaces
{
    public interface IKeyManager: IService
    {
        Task AddKeysAsync(Guid gameId,IEnumerable<string> keys);     
        
    }
    
}