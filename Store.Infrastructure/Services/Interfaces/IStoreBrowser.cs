using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Services.Interfaces
{
    public interface IStoreBrowser
    {
        Task<IEnumerable<GameDto>> BrowseGamesAsync(string term, double minprice,
                     double maxprice, string platform, IEnumerable<string> categories, int page);
        Task<IEnumerable<GameDto>> BrowseGamesAsync(int page);
    }
}