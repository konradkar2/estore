using System;
using System.Collections.Generic;

namespace Store.Core.Domain
{
    public class Category
    {
        public Guid Id;   
        public string Name {get; protected set;}
        public IEnumerable<GameCategory> GameCategories {get;protected set;}
        protected Category() {}
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}