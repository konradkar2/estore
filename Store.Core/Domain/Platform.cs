using System;

namespace Store.Core.Domain
{
    public class Platform
    {
        public Guid Id {get;protected set;}
        public string Name {get;protected set;}
        protected Platform(){}
        public Platform(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}