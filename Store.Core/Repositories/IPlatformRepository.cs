using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface IPlatformRepository
    {
        Task<Platform> GetAsync(Guid id);
         Task<IEnumerable<Platform>> BrowseAsync();
         Task AddAsync(Platform platform);
         Task UpdateAsync(Platform platform);
         Task RemoveAsync(Platform platform);    
    }
}