using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Services.Interfaces
{
    public interface IGameManager : IService
    {
        Task<GameDto> GetAsync(string name);
        Task<GameDto> GetAsync(Guid id);
        Task<IEnumerable<GameDto>> BrowseAsync();
        Task CreateGameAsync(Guid id, string name, decimal price, int quantity,string description,
                string ageCategory,DateTime releaseDate, bool isDigital,string platformName, IEnumerable<string> categories);
        Task CreateCategoryAsync(Guid id, string name);     
        
       
    }
}