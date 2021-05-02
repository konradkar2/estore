using System;
using System.Collections.Generic;
using Store.Core.Extensions;

namespace Store.Core.Domain
{
    public class Game
    {
        public Guid Id {get;protected set;}
        public string Name {get;protected set;}
        public decimal Price {get;protected set;}
        public int Quantity {get;protected set;}
        public string Description{get;protected set;}
        public string AgeCategory {get;protected set;}
        public DateTime ReleaseDate {get;protected set;}
        public bool IsDigital{get;protected set;}
        public Guid PlatformId{get;protected set;}
        public Platform _Platform{get;protected set;}
        public IEnumerable<GameCategory> GameCategories {get; protected set;}
        protected Game(){}
        
        public Game(Guid id, string name, decimal price, int quantity,string description,
                string ageCategory,DateTime releaseDate, bool isDigital,Guid platformId)
        {
            Id = id;
            SetName(name);
            SetPrice(price);
            SetQuantity(quantity);
            Description = description;
            AgeCategory = ageCategory;
            IsDigital = isDigital;
            PlatformId = platformId;
        }
        private void SetName(string name)
        {
            if(name.Empty()){
                throw new Exception("Game name cannot be empty");
            }
            Name = name;
        }
        private void SetPrice(decimal price)
        {
            if(price.IsNegative()){
                throw new Exception("Price cannot be less than 0");
            }
            Price = price;
        }
        private void SetQuantity(int quantity)
        {
            if(quantity.IsNegative()){
                throw new Exception("Quantity cannot be less than 0");
            }
            Quantity = quantity;
        }
    }
}