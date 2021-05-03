using System;
using System.Collections.Generic;

namespace Store.Infrastructure.Commands.Key
{
    public class AddKeys : ICommand
    {
        public Guid GameId {get;set;}
        public IEnumerable<string> Keys {get;set;}
    }
}