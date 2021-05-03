using System;
using System.Collections.Generic;

namespace Store.Infrastructure.Commands.Game
{
    public class BuyGames : ICommand
    {
        public Guid UserId {get;set;}
        public IDictionary<Guid,int> Cart {get;set;}
        
    }
}