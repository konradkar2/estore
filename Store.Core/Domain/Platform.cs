using System;
using System.Collections.Generic;
using Store.Core.Extensions;

namespace Store.Core.Domain
{
    public class Platform
    {
        public Guid Id {get;protected set;}
        public string Name {get;protected set;}
        public IEnumerable<Game> Games {get;protected set;}
        protected Platform(){}
        public Platform(Guid id, string name)
        {
            Id = id;
            SetName(name);
        }
        private void SetName(string name)
        {
            if (name.Empty())
            {
                throw new Exception("Platform name can not be empty");
            }
            Name = name.ToLowerInvariant();
        }
    }
}