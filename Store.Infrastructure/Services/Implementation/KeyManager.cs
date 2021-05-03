using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Store.Core.Domain;
using Store.Core.Repositories;
using Store.Infrastructure.DTO;
using Store.Infrastructure.Services.Implementation.Extensions;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Services.Implementation
{
    public class KeyManager : IKeyManager
    {
        private readonly IGameRepository _gameRepository;      
        private readonly IKeyRepository _keyRepository;
        private readonly IMapper _mapper;
        public KeyManager (IMapper mapper, IGameRepository gameRepository,
          IKeyRepository keyRepository)
         {
            _gameRepository = gameRepository;           
            _keyRepository = keyRepository;
            _mapper = mapper;
         }

        public async Task AddKeysAsync(Guid gameId, IEnumerable<string> keys)
        {
            var game = await _gameRepository.GetOrFailAsync(gameId);
            var dbkeys = await _keyRepository.BrowseAsync(gameId,keys);
            if(dbkeys.Any())
            {
                var temp = string.Join(",",dbkeys.Select(x => x.GKey));
                throw new Exception($"Game of id '{gameId}' already contains provided keys: '{temp}' ");
            }
            var Keys = keys.Select(key => new Key(Guid.NewGuid(),gameId,used: false, key));
            await _keyRepository.AddManyAsync(Keys);
            await _keyRepository.SaveChangesAsync();
            
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