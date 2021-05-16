using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FluentAssertions;
using Moq;
using Store.Core.Domain;
using Store.Core.Repositories;
using Store.Infrastructure.DTO;
using Store.Infrastructure.Mappers;
using Store.Infrastructure.Services;
using Store.Tests.Unit.utilities;
using Xunit;

namespace Store.Tests.Unit
{
    public class UserServiceTests
    {
        private IMapper _mapper;
        public UserServiceTests()
        {
            _mapper = AutoMapperConfig.Initialize();     
        }   
        [Fact]
        public async Task When_calling_get_user_that_doesnt_exists_should_return_null()
        {
            var userRepositoryMock = new Mock<IUserRepository>();          
            var encrypterMock = new Mock<IEncrypter>();              
            var userService = new UserService(userRepositoryMock.Object,_mapper,encrypterMock.Object);             
            userRepositoryMock.Setup(x => x.GetAsync(It.IsAny<string>())).ReturnsAsync((User)null);   
            var email = "user1@email.com";

            var userDto = await userService.GetAsync(email);
            
            userDto.Should().BeNull();  
        }
        [Fact]
        public async Task When_calling_get_user_that_exists_should_return_user_dto()
        {
            var userRepositoryMock = new Mock<IUserRepository>();  
            var encrypterMock = new Mock<IEncrypter>();              
            var userService =new UserService(userRepositoryMock.Object,_mapper,encrypterMock.Object);    
            var email = "user1@email.com";
            Guid userId = Guid.NewGuid();
            string role = "user";
            var user = new User(userId,"user1",email,"secret","salt",role);
            var properUserDto = _mapper.Map<UserDto>(user);
            userRepositoryMock.Setup(x => x.GetAsync(email)).ReturnsAsync(user);            
            
            var userDto = await userService.GetAsync(email);

            userDto.Should().BeEquivalentTo(userDto);
        }
        [Fact]
        public async Task When_calling_browse_users_on_empty_user_repository_should_return_empty_enumerable()
        {
            var userRepositoryMock = new Mock<IUserRepository>();          
            var encrypterMock = new Mock<IEncrypter>();              
            var userService = new UserService(userRepositoryMock.Object,_mapper,encrypterMock.Object);             
            userRepositoryMock.Setup(x => x.BrowseAsync(It.IsAny<int>(),It.IsAny<int>())).ReturnsAsync(Enumerable.Empty<User>());   
           

            var usersDto = await userService.BrowseAsync(0,10);
            
            usersDto.Should().BeEmpty();
        }
        [Fact]
        public async Task When_calling_browse_users_on_not_empty_user_repository_should_return_proper_user_dto_enumerable()
        {
            var userRepositoryMock = new Mock<IUserRepository>();          
            var encrypterMock = new Mock<IEncrypter>();              
            var userService = new UserService(userRepositoryMock.Object,_mapper,encrypterMock.Object);  
            
            int usersNumberToCreate = 50;
            var users = UsersUtilities.GenerateManyUsers(usersNumberToCreate);           
            userRepositoryMock.Setup(x => x
                              .BrowseAsync(It.Is<int>(x => x==0),It.Is<int>(x => x >= usersNumberToCreate)))
                              .ReturnsAsync(users);   
            var properUserDtos = _mapper.Map<IEnumerable<UserDto>>(users);

            int usersNumberToGet = usersNumberToCreate + 10;
            var usersDto = await userService.BrowseAsync(0,usersNumberToGet);
            
            usersDto.Should().BeEquivalentTo(properUserDtos);
        }
        
        
    }
}