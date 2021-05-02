using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Store.Infrastructure.DTO;

namespace Store.Infrastructure.Services.Interfaces
{
    public interface IUserService : IService
    {
         Task<UserDto> GetAsync(string email);
         Task<UserDto> GetAsync(Guid id);
         Task RegisterAsync(Guid userId,string email, string username,string password, string role);

         Task<IEnumerable<UserDto>> BrowseAsync(int offset, int limit);
         Task LoginAsync(string email,string password);

    }
}