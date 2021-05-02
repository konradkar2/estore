using System;

namespace Store.Infrastructure.DTO
{
    public class GameCategoryDto
    {
        public Guid Id {get;protected set;}       
        public CategoryDto Category {get;protected set;}
    }
}