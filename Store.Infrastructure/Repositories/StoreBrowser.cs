using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Store.Core.Repositories;
using Store.Infrastructure.DTO;
using Store.Infrastructure.Services.Interfaces;
using Store.Infrastructure.Settings;

namespace Store.Infrastructure.Repositories
{
    public class StoreBrowser : IStoreBrowser
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        private readonly PaginationSettings _paginationSettings;
        public StoreBrowser(IGameRepository gameRepository, IMapper mapper,
                PaginationSettings paginationSettings)
        {
            _
        }
        public Task<IEnumerable<GameDto>> BrowseGamesAsync(string term, double minprice, double maxprice,
                     string platform, IEnumerable<string> categories, int page)
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<GameDto>> BrowseGamesAsync(int page)
        {
            throw new System.NotImplementedException();
        }
    }
}