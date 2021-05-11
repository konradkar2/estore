using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Store.Core.Domain;
using Store.Core.Extensions;
using Store.Core.Repositories;
using Store.Infrastructure.DTO;
using Store.Infrastructure.Services.Implementation.Extensions;
using Store.Infrastructure.Services.Interfaces;
using Store.Infrastructure.Settings;

namespace Store.Infrastructure.Services.Implementation
{
    public class StoreBrowser : IStoreBrowser
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        private readonly PaginationSettings _paginationSettings;
        private readonly IKeyBrowser _keyBrowser;
        public StoreBrowser(IGameRepository gameRepository, IMapper mapper,
                PaginationSettings paginationSettings, IKeyBrowser keyBrowser)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
            _paginationSettings = paginationSettings;
            _keyBrowser = keyBrowser; 
        }
        public async Task<IEnumerable<GameDto>> BrowseGamesAsync(string term, double? minprice, double? maxprice,
                     string platform, bool? isDigital,IEnumerable<string> categories, int page)
        {
            if(page.IsNegative())
            {
                throw new Exception("Page number cannot be negative");
            }
            int take = _paginationSettings.GamesPerPage;
            int skip = take * page;           
           
            Expression<Func<Game,bool>> filter;
            if (!term.Empty())
                filter = g => g.Name.Contains(term.ToLowerInvariant());
            else
                filter = g => true; //just to initialize filter
            if(!platform.Empty())
                filter = filter.AndAlso( g => g.Platform.Name == platform.ToLowerInvariant());
            if(minprice != null)
            {
                filter = filter.AndAlso(g => g.Price >= (decimal)minprice);
            }
            if(maxprice != null)
            {
                filter = filter.AndAlso(g => g.Price <= (decimal)maxprice);
            }
            if(isDigital != null)
            {
                filter = filter.AndAlso(g => g.IsDigital == isDigital);
            }
            if(categories != null && categories.Any())
            {
                filter = filter.AndAlso(g => g.GameCategories.Any(gc => categories.Any(c => gc.Category.Name == c)));
            }             
                
            var results = await _gameRepository.BrowseAsync(filter,skip, take);
            return _mapper.Map<IEnumerable<GameDto>>(results);

        }

        public async Task<IEnumerable<GameDto>> BrowseGamesAsync(int page)
        {
            if(page.IsNegative())
            {
                throw new Exception("Page number cannot be negative");
            }
            int take = _paginationSettings.GamesPerPage;
            int skip = take * page;
            var results = await _gameRepository.BrowseAsync(skip, take);
            return _mapper.Map<IEnumerable<GameDto>>(results);
            
        }        

        public async Task<GameDto> GetAsync(Guid id)
        {
            var game = await _gameRepository.GetOrFailAsync(id);
            return _mapper.Map<GameDto>(game);
        }        

        public async Task<int> GetCopyCount(Guid gameId)
        {
            var game = await _gameRepository.GetOrFailAsync(gameId);
            if(!game.IsDigital)
            {
                return game.Quantity;
            }
            else
            {
                return await _keyBrowser.GetNotUsedKeyCount(gameId);
            }
        }
       
    }
}