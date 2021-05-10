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
    public class StoreManager : IStoreManager
    {
        private readonly IGameRepository _gameRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IGameCategoryRepository _gameCategoryRepository;
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;
        public StoreManager(IMapper mapper, IGameRepository gameRepository,
         ICategoryRepository categoryRepository, IGameCategoryRepository gameCategoryRepository,
         IPlatformRepository platformRepository)
         {
            _gameRepository = gameRepository;
            _categoryRepository = categoryRepository;
            _gameCategoryRepository = gameCategoryRepository;
            _platformRepository = platformRepository;
           
            _mapper = mapper;
         }                

        public async Task CreateCategoryAsync(Guid id, string name)
        {
            var category = await _categoryRepository.GetAsync(name.ToLowerInvariant());
            if(category != null)
            {
                throw new Exception($"Category with name '{name}' already exists.");
            }
            category = new Category(id,name);
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task CreateGameAsync(Guid id, string name, decimal price, int quantity, string description,
         string ageCategory, DateTime releaseDate, bool isDigital, string platformName, IEnumerable<string> categories)
        {
            
            //if(!categories.Any()) throw... - currently you can add games without categories           
            var availableCategories = await _categoryRepository.BrowseAsync();
            var notMatched = categories.Where(c => !availableCategories.Any(ac => ac.Name == c.ToLowerInvariant()));
            if(notMatched.Any())
            {
                string temp = string.Join(",",notMatched);
                throw new Exception($"Categories '{temp}' are not in database");
            }
            var platform = await _platformRepository.GetAsync(platformName.ToLowerInvariant());
            if(platform == null)
            {
                throw new Exception($"Platform of name '{platformName.ToLowerInvariant()}' does not exists.");
            }
            var game = new Game(id,name,price,quantity,description,ageCategory,releaseDate,isDigital,platform.Id);
            await _gameRepository.AddAsync(game);
            var cats = availableCategories.Where(x => categories.Any(c => x.Name == c));
            foreach(var cat in cats)
            {
                var catId = Guid.NewGuid();
                var gameCategory = new GameCategory(catId,id,cat.Id);
                await _gameCategoryRepository.AddAsync(gameCategory);
            }
            await _gameRepository.SaveChangesAsync();

        }

        
    }
}