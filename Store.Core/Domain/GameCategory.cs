using System;
using System.Collections.Generic;

namespace Store.Core.Domain
{
    public class GameCategory
    {
        public Guid Id {get;protected set;}
        public Guid GameId {get;protected set;}
        public Game Game {get; protected set;}
        public Guid CategoryId {get;protected set;}
        public Category Category {get;protected set;}
        public GameCategory(Guid id, Guid gameId, Guid categoryId)
        {
            Id = id;
            GameId = gameId;
            CategoryId = categoryId;
        }
       
    }
}