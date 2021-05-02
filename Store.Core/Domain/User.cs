using System;
using System.Collections.Generic;
using System.Net.Mail;
using Store.Core.Extensions;

namespace Store.Core.Domain
{
    public class User
    {
        public Guid Id {get;protected set;}
        public string Name {get;protected set;}
        public string Email {get;protected set;}
        public string Role {get;protected set;}
        public string PasswordHash {get; protected set;}
        public string Salt {get;set;}
        public IEnumerable<UserTransaction> UserTransactions {get; protected set;}
        protected User(){}

        public User(Guid id, string name, string email, string role, string passwordHash, string salt)
        {
            Id = id;
            SetEmail(email);
            SetName(name);
            SetRole(role);
            SetPasswordHash(passwordHash);
            SetSalt(salt);

        }
        private void SetName(string name)
        {
            if(name.Empty())
            {
                throw new Exception("Name cannot be empty");
            }
            Name = name;
        }
        private void SetRole(string role)
        {
            if(role.Empty())
            {
                throw new Exception("Role cannot be empty");
            }
            Role = role;
        }
        private void SetPasswordHash(string passwordHash)
        {
            if(passwordHash.Empty())
            {
                throw new Exception("password hash cannot be empty"); //should be internal serr
            }
            Name = passwordHash;
        }
        private void SetSalt(string salt)
        {
            if(salt.Empty())
            {
                throw new Exception("Salt cannot be empty");//should be internal serr
            }
            Salt = salt;
        }
        private void SetEmail(string email)
        {
            email = email.ToLowerInvariant();
            try
            {
                MailAddress m = new MailAddress(email);                
            }
            catch (Exception)
            {
                throw new Exception("Provided email is invalid"); //TODO create domain exceptions
            }
            Email = email;
            
        }

    }
}