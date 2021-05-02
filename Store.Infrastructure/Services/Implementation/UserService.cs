using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Store.Core.Domain;
using Store.Core.Extensions;
using Store.Core.Repositories;
using Store.Infrastructure.DTO;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEncrypter _encrypter;
        public UserService(IUserRepository userRepository, IMapper mapper, IEncrypter encrypter)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _encrypter = encrypter;
        }
        public async Task<IEnumerable<UserDto>> BrowseAsync(int offset, int limit)
        {
            if (offset.IsNegative() || limit.IsNegative())  // should be moved into DTO?
            {
                throw new Exception("Offset/Limit can not be a negative number");
            }
            var users = await _userRepository.BrowseAsync(offset,limit);
            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task<UserDto> GetAsync(string email)
        {
            var user = await _userRepository.GetAsync(email);
            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);
            return _mapper.Map<UserDto>(user);
        }

        public Task LoginAsync(string email, string password)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterAsync(Guid userId, string email, string username, string password, string role)
        {
            var user = await _userRepository.GetAsync(email);
            if(user != null)
            {
                throw new Exception($"User with that email '{email}' already exists.");
            }
            user = await _userRepository.GetAsync(userId);
            if(user != null)
            {
                throw new Exception($"User with that guid '{userId}' already exists.");
            }
            var salt = _encrypter.GetSalt();
            var hash = _encrypter.GetHash(password,salt);            
            user = new User(userId,username,email,role,hash,salt);
            await _userRepository.AddAsync(user);
            await _userRepository.SaveChangesAsync();

        }
    }
}