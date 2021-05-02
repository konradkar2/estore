using System;

namespace Store.Infrastructure.Commands.Platform
{
    public class CreatePlatform : ICommand
    {
        public Guid Id {get;set;}
        public string Name {get ;set;}
    }
}