using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Store.Core.Domain;
using Store.Core.Repositories;
using Store.Infrastructure.Services.Implementation.Extensions;
using Store.Infrastructure.Services.Interfaces;
using System.Linq;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Services.Implementation
{
    public class TransactionManager : ITransactionManager
    {
        private readonly IGameRepository _gameRepository;
        private readonly IKeyRepository _keyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserTransactionRepository _userTransactionRepository;
        private readonly IGameTransactionRepository _gameTransactionRepository;
        private readonly IStoreBrowser _storeBrowser;
        private readonly IMapper _mapper;
        public TransactionManager(IMapper mapper, IGameRepository gameRepository,
            IGameTransactionRepository gameTransactionRepository, IKeyRepository keyRepository,
            IUserTransactionRepository userTransactionRepository, IUserRepository userRepository,
            IStoreBrowser storeBrowser)
         {
            _gameRepository = gameRepository;            
            _keyRepository = keyRepository;
            _gameTransactionRepository = gameTransactionRepository;
            _userTransactionRepository = userTransactionRepository;
            _mapper = mapper;
            _userRepository = userRepository;
            _storeBrowser = storeBrowser;
         }

        public async Task<IEnumerable<UserTransactionDto>> BrowseUsersTransaction(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);  
            var user_transactions = await _userTransactionRepository.GetManyAsync(userId);

            return _mapper.Map<IEnumerable<UserTransactionDto>>(user_transactions);
        }

        public async Task BuyGames(Guid userId, IDictionary<Guid, int> gameIdQuantity)
        {
            var user = await _userRepository.GetOrFailAsync(userId);   
            //begin transaction...    
            foreach(var (gameId,quantity) in gameIdQuantity)
            {
                if(quantity < 0)
                {
                    throw new Exception("Qountity cannot be a negative number");
                }
                var game = await _gameRepository.GetOrFailAsync(gameId);
                var count = await _storeBrowser.GetCopyCount(gameId);
                if(quantity > count)
                {
                    throw new Exception($"Game of '{game.Name} {game.Id}' exits only in {count}, request was {quantity} ");
                }
            }
            var userTransaction = new UserTransaction(Guid.NewGuid(),userId,DateTime.UtcNow);
            foreach(var (gameId,quantity) in gameIdQuantity)
            {                
                await _userTransactionRepository.AddAsync(userTransaction);
                var keys = await _keyRepository.TakeManyNotUsedAsync(gameId,quantity);
                //set used to true on keys
                keys = keys.Select(k => new Key(k.Id,k.GameId,used: true,k.GKey)).ToList();
                var gameTransactions = keys.Select(k => new GameTransaction(Guid.NewGuid(),userTransaction.Id,gameId,k.Id));
                foreach(var key in keys)
                {
                    _keyRepository.Update(key);
                }
                foreach(var gt in gameTransactions)
                {
                    await _gameTransactionRepository.AddAsync(gt);
                }              

            }

        }
    }
}