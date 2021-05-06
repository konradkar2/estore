using System.Collections.Generic;

namespace Store.Infrastructure.Commands.Game
{
    public class SearchGames : PaginationCommandBase
    {
        public string Term {get;set;}
        public double MinPrice {get;set;}
        public double MaxPrice{get;set;}
        public string Platform {get;set;}
        public bool IsDigital {get;set;}
        public IEnumerable<string> Categories {get;set;}

    }
}