using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Services.Interfaces
{
    public interface IGameService
    {
        Task<GameDto> GetAsync(string name);
        Task<GameDto> GetAsync(Guid id);
        Task CreateAsync(Guid id, string name, decimal price, int quantity,string description,
                string ageCategory,DateTime releaseDate, bool isDigital,Guid platformId, IEnumerable<string> categories);
        
       
    }
}