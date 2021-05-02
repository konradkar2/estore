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
    public class PlatformService : IPlatformService
    {
        private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;        
        public PlatformService(IMapper mapper, IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
            
        }
        public async Task<IEnumerable<PlatformDto>> BrowseAsync()
        {
            var platforms = await _platformRepository.BrowseAsync();
            return _mapper.Map<IEnumerable<PlatformDto>>(platforms);
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

        public async Task<PlatformDto> GetAsync(string name)
        {
            var platform = await _platformRepository.GetAsync(name);
            return _mapper.Map<PlatformDto>(platform);
        }

        public async Task<PlatformDto> GetAsync(Guid id)
        {
            var platform = await _platformRepository.GetAsync(id);
            return _mapper.Map<PlatformDto>(platform);
        }
    }
}