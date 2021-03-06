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
                cfg.CreateMap<GameCategory,CategoryDto>()                            
                            .ForMember(c => c.Id, opt => opt.MapFrom(gc => gc.Category.Id))
                            .ForMember(c => c.Name, opt => opt.MapFrom(gc => gc.Category.Name));
                cfg.CreateMap<Game,GameDto>()
                            .ForMember(dto => dto.Categories, opt => opt.MapFrom(g => g.GameCategories));
                cfg.CreateMap<UserTransaction,GameTransactionDto>()
                            .ForMember(gt => gt.Game, opt => opt.MapFrom(ut => ut.GameTransactions));
                cfg.CreateMap<Category,CategoryDto>();               
                cfg.CreateMap<Key,KeyDto>();      
                cfg.CreateMap<GameTransaction,GameTransactionDto>();
                cfg.CreateMap<UserTransaction,UserTransactionDto>();
                
            });
            return configuration.CreateMapper();
        }
    }
}