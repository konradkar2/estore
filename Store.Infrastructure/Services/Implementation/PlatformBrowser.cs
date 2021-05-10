using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Store.Core.Repositories;
using Store.Infrastructure.DTO;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Services.Implementation
{
    public class PlatformBrowser : IPlatformBrowser
    {
         private readonly IPlatformRepository _platformRepository;
        private readonly IMapper _mapper;        
        public PlatformBrowser(IMapper mapper, IPlatformRepository platformRepository)
        {
            _platformRepository = platformRepository;
            _mapper = mapper;
            
        }
        public async Task<IEnumerable<PlatformDto>> BrowseAsync()
        {
            var platforms = await _platformRepository.BrowseAsync();
            return _mapper.Map<IEnumerable<PlatformDto>>(platforms);
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