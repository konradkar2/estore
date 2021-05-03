using System;

namespace Store.Infrastructure.DTO
{
    public class KeyDto
    {
        public Guid Id {get;protected set;}        
        public bool Used {get;protected set;}
        public string GKey{get;protected set;}
    }
}