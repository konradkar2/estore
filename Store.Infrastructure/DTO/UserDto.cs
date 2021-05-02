using System;

namespace Store.Infrastructure.DTO
{
    public class UserDto
    {
        public Guid Id {get; set;}
        public string Username {get;set;}
        public string Email {get; set;}

    }
}