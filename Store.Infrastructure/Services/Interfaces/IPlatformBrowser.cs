using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Services.Interfaces
{
    public interface IPlatformBrowser
    {
         Task<PlatformDto> GetAsync(string name);
         Task<PlatformDto> GetAsync(Guid id);        
         Task<IEnumerable<PlatformDto>> BrowseAsync();
    }
}