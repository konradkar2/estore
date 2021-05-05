using System;
using System.Collections.Generic;

namespace Store.Infrastructure.DTO
{
    public class UserTransactionDto
    {
        public Guid Id {get;set;}
        public DateTime Date {get;set;}
        public IEnumerable<GameTransactionDto> GameTransactions;
        
    }
}