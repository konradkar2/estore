using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Store.Infrastructure.Services.Interfaces;
using Store.Infrastructure.Settings;

namespace Store.Infrastructure.Services.Implementation
{
    public class DataInitializer : IDataInitializer
    {
        private readonly GeneralSettings _settings;
        private readonly IStoreManager _storeManager;
        private readonly IKeyManager _keyManager;
        private readonly IUserService _userService;
        private readonly IPlatformManager _platformManager;
        public DataInitializer(GeneralSettings settings, IStoreManager storeManager,
        IKeyManager keyManager, IUserService userService, IPlatformManager platformManager)
        {
            _settings = settings;
            _storeManager = storeManager;
            _keyManager = keyManager;
            _userService = userService;
            _platformManager = platformManager;
        }
        public async Task SeedAsync()
        {
            var users = await _userService.BrowseAsync(0,1);
            if(users.Any())
            {
                return;
            }
            int i =0;
            //create 10 users
            for(i=0 ; i < 10; i++)
            {
                var username = $"user{i}";
                var email = $"{username}@email.com";
                var userId = Guid.NewGuid();
                var password = "secret";
                var role = "user";
                await _userService.RegisterAsync(userId,email,username,password,role);
            }
            //create platforms 
            var platforms = new List<string>{"pc","ps4","xbox"};
            foreach(var platform in platforms)
            {
                var platformId = Guid.NewGuid();
                await _platformManager.CreateAsync(platformId, platform);
            }
            //create categories
            var categories = new List<string>{"sport","rpg","shooter","tower defence","action"};
            foreach(var category in categories)
            {
                var categoryId = Guid.NewGuid();
                await _storeManager.CreateCategoryAsync(categoryId,category);
            }
            //create games
            i = 0;
            foreach(var platform in platforms)
            {
                var gameCategories = new List<string>();
                foreach(var category in categories)
                {
                    categories.Add(category);
                    var title = $"Game{i}";
                    var description = $"Description of {title}";
                    decimal price = i * 10m + i/10m;
                    var gameId = Guid.NewGuid();
                    bool digital = i % 2 == 0;
                    var quantity = i * 20;
                    if(digital)
                    {
                        quantity = 0;
                    }
                    await _storeManager.CreateGameAsync(gameId,title,price,quantity,description, )
                    i++;
                }
            }
            
        }
    }
}