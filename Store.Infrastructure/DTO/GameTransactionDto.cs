using System;

namespace Store.Infrastructure.DTO
{
    public class GameTransactionDto
    {
        public Guid Id {get;protected set;}   
        public Guid KeyId{get;protected set;}
        public KeyDto Key {get;protected set;}
        public GameDto Game {get;protected set;}

    }
}