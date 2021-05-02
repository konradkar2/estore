using AutoMapper;
using Store.Core.Domain;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Mappers
{
    public static class AutoMapperConfig
    {
        public static IMapper Initialize(){
            var configuration = new MapperConfiguration(cfg =>{
                cfg.CreateMap<User,UserDto>();
                cfg.CreateMap<Platform,PlatformDto>();              
                cfg.CreateMap<GameCategory,GameCategoryDto>();              
                cfg.CreateMap<GameCategory,GameCategoryDetailsDto>();              
                cfg.CreateMap<Game,GameDto>();               
                
            });
            return configuration.CreateMapper();
        }
    }
}