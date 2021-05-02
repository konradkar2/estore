using System;
using System.Collections.Generic;

namespace Store.Core.Domain
{
    public class UserTransaction
    {
        public Guid Id {get;protected set;}
        public Guid UserId {get;protected set;}
        public User User {get;protected set;}
        public IEnumerable<GameTransaction> GameTransactions {get; protected set;}
        
        public DateTime Date {get;protected set;}
        protected UserTransaction(){}
        public UserTransaction(Guid id, Guid userId, DateTime date)
        {
            Id = id;
            UserId = userId;
            Date = date;
        }

    }
}