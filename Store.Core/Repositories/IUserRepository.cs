using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;

namespace Store.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task<IEnumerable<User>> BrowseAsync(int offset, int limit);
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task RemoveAsync(Guid id);    
    }
}