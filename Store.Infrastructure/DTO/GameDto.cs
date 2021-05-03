using System;
using System.Collections.Generic;

namespace Store.Infrastructure.DTO
{
    public class GameDto
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public decimal Price {get; set;}
        public int Quantity {get; set;}
        public string Description{get; set;}
        public string AgeCategory {get; set;}
        public DateTime ReleaseDate {get; set;}
        public bool IsDigital{get; set;}
        public Guid PlatformId{get; set;}
        public PlatformDto Platform{get; set;}
        public IEnumerable<CategoryDto> Categories {get;  set;}
        
    }
}