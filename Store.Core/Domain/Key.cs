using System;

namespace Store.Core.Domain
{
    public class Key
    {
        public Guid Id {get;protected set;}
        public Guid GameId {get; protected set;}
        public Game Game {get;protected set;}
        public bool Used {get;protected set;}
        public string GKey{get;protected set;}
        protected Key(){}
        public Key(Guid id, Guid gameId, bool used, string gkey)
        {
            Id = id;
            GameId = gameId;
            Used = used;
            GKey = gkey;
        }
        
    }
}