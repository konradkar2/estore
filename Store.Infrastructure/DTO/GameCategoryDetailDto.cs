using System;

namespace Store.Infrastructure.DTO
{
    public class GameCategoryDetailsDto
    {
        public Guid Id {get;protected set;}
        public Guid GameId {get;protected set;}       
        public Guid CategoryId {get;protected set;}
        public CategoryDto Category {get;protected set;}
    }
}