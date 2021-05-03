using System;

namespace Store.Core.Domain
{
    public class GameTransaction
    {
        public Guid Id {get;protected set;}
        public Guid UserTransactionId {get; protected set;}
        public UserTransaction UserTransaction {get;protected set;}
        public Guid GameId {get;protected set;}
        public Key Game {get;protected set;}
        public Guid KeyId{get;protected set;}
        public Key Key {get;protected set;}

        protected GameTransaction(){}
        public GameTransaction(Guid id, Guid userTransactionId, Guid gameId, Guid keyId)
        {
            Id = id;
            UserTransactionId = userTransactionId;
            GameId = gameId;
            KeyId = keyId;
        }
    
    }
}