using System;
using System.Collections.Generic;
using System.Net.Mail;
using Store.Core.Extensions;

namespace Store.Core.Domain
{
    public class User
    {
        public Guid Id {get;protected set;}
        public string Username {get;protected set;}
        public string Email {get;protected set;}
        public string Role {get;protected set;}
        public string PasswordHash {get; protected set;}
        public string Salt {get;set;}
        public IEnumerable<UserTransaction> UserTransactions {get; protected set;}
        protected User(){}

        public User(Guid id, string username, string email, string role, string passwordHash, string salt)
        {
            Id = id;
            SetEmail(email);
            SetName(username);
            SetRole(role);
            SetPasswordHash(passwordHash);
            SetSalt(salt);

        }
        private void SetName(string username)
        {
            if(username.Empty())
            {
                throw new Exception("Name cannot be empty");
            }
            Username = username;
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
            PasswordHash = passwordHash;
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