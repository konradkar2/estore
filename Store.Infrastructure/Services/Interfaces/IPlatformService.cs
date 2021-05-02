using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Services.Interfaces
{
    public interface IPlatformService : IService
    {
        Task<PlatformDto> GetAsync(string name);
        Task<PlatformDto> GetAsync(Guid id);        
        Task<IEnumerable<PlatformDto>> BrowseAsync();
        Task CreateAsync(Guid id, string name);
    }
}