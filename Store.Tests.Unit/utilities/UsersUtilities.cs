using System;
using System.Collections.Generic;
using Store.Core.Domain;

namespace Store.Tests.Unit.utilities
{
    public static class UsersUtilities
    {
        public static IEnumerable<User> GenerateManyUsers(int n)
        {
            var users = new List<User>();
            for(int i = 0; i< n ;i++)
            {
                var username = $"user{i}";
                var email = $"{username}@email.com";
                Guid userId = Guid.NewGuid();
                string role = "user";
                var user = new User(userId,username,email,"secret","salt",role);

                users.Add(user);                
            }
            return users;
            
        }
    }
}