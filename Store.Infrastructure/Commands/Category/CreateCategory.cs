using System;

namespace Store.Infrastructure.Commands.Category
{
    public class CreateCategory : ICommand
    {
        public Guid Id {get; set;}
        public string Name {get;  set;}
    }
}