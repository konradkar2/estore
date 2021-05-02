using System;
using System.Collections.Generic;
using Store.Core.Extensions;

namespace Store.Core.Domain
{
    public class Category
    {
        public Guid Id {get; protected set;}  
        public string Name {get; protected set;}
        public IEnumerable<GameCategory> GameCategories {get;protected set;}
        protected Category() {}
        public Category(Guid id, string name)
        {
            Id = id;
            SetName(name);
        }
        private void SetName(string name)
        {
            if(name.Empty())
            {
                throw new Exception("Category name can not be empty");
            }
            Name = name.ToLowerInvariant();
        }
    }
}