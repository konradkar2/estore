using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Services.Interfaces
{
    public interface IPlatformManager : IService
    {        
        Task CreateAsync(Guid id, string name);
    }
}