using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface IPlatformRepository : IRepository
    {
        Task<Platform> GetAsync(Guid id);
        Task<Platform> GetAsync(string name);
         Task<IEnumerable<Platform>> BrowseAsync();
         Task AddAsync(Platform platform);
         Task Update(Platform platform);
         Task RemoveAsync(Guid id);    
    }
}