using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Store.Core.Repositories;
using Store.Infrastructure.DTO;
using Store.Infrastructure.Services.Implementation.Extensions;

namespace Store.Infrastructure.Services.Implementation
{
    public class KeyBrowser
    {
        private readonly IGameRepository _gameRepository;      
        private readonly IKeyRepository _keyRepository;      
        private readonly IMapper _mapper;
         public KeyBrowser (IGameRepository gameRepository,
          IKeyRepository keyRepository, IMapper mapper)
         {
            _gameRepository = gameRepository;           
            _keyRepository = keyRepository;
            _mapper = mapper;          
         }
         public async Task<IEnumerable<KeyDto>> BrowseKeysAsync(Guid gameId)
        {
           var keys = await _keyRepository.BrowseAsync(gameId);
           return _mapper.Map<IEnumerable<KeyDto>>(keys);
        }

        public async Task<int> GetNotUsedKeyCount(Guid gameId)
        {
            var game = await _gameRepository.GetOrFailAsync(gameId);
            if(!game.IsDigital)
            {
                throw new Exception($"Game of id '{gameId}' is not digital");
            }
            int count = await _keyRepository.GetNotUsedCountAsync(gameId);
            return count;
        }
    }
}