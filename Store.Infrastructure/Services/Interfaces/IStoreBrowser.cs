using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Services.Interfaces
{
    public interface IStoreBrowser : IService
    {
        Task<IEnumerable<GameDto>> BrowseGamesAsync(string term, double? minprice,
                     double? maxprice, string platform,bool? isDigital, IEnumerable<string> categories, int page);
        Task<IEnumerable<GameDto>> BrowseGamesAsync(int page);
    }
}