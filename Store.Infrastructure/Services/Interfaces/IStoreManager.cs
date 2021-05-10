using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Services.Interfaces
{
    public interface IStoreManager : IService
    {
           
        Task CreateGameAsync(Guid gameId, string name, decimal price, int quantity,string description,
                string ageCategory,DateTime releaseDate, bool isDigital,string platformName, IEnumerable<string> categories);
        Task CreateCategoryAsync(Guid categoryId, string name);       
        
       
    }
}