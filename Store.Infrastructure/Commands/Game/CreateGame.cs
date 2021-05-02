using System;
using System.Collections.Generic;

namespace Store.Infrastructure.Commands.Game
{
    public class CreateGame : ICommand
    {
        public Guid Id {get; set;}
        public string Name {get; set;}
        public decimal Price {get; set;}
        public int Quantity {get; set;}
        public string Description{get; set;}
        public string AgeCategory {get; set;}
        public DateTime ReleaseDate {get; set;}
        public bool IsDigital{get; set;}
        public string platformName{get; set;}        
        public IEnumerable<String> Categories {get;  set;}
    }
}