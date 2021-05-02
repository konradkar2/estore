using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Core.Domain;
using Store.Core.Repositories;
using Store.Infrastructure.EF;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Store.Infrastructure.Repositories
{
    public class UserRepository : ISqlRepository,IUserRepository
    {
        private readonly StoreContext _context;
        public UserRepository(StoreContext context)
        {
            _context = context;
        }
        public async Task AddAsync(User user)
        {
            await _context.User.AddAsync(user);            
        }
        public async Task<IEnumerable<User>> BrowseAsync(int offset, int limit)
                => await _context.User.OrderBy(x => x.Email).Skip(offset).Take(limit).ToListAsync();

        public async Task<User> GetAsync(Guid id)
                => await _context.User.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<User> GetAsync(string email)
                => await _context.User.SingleOrDefaultAsync(x => x.Email == email);

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);
            _context.User.Remove(user);            
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Update(User user)
        {
             _context.User.Update(user);
        }
    }
}