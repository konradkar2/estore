using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Store.Core.Domain;
using Store.Core.Extensions;
using Store.Core.Repositories;
using Store.Infrastructure.DTO;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Services.Implementation
{
    public class PlatformManager : IPlatformManager
    {
        private readonly IPlatformRepository _platformRepository;
        public PlatformManager(IMapper mapper, IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;           
            
        }       
        public async Task CreateAsync(Guid id, string name)
        {           
            
            var platform = await _platformRepository.GetAsync(name);
            if(platform != null)
            {
                throw new Exception($"Platform of name '{name}' already exists.");
            }
            platform = new Platform(id,name);
            await _platformRepository.AddAsync(platform);           
        }      
    }
}