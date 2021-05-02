using System;
using System.Threading.Tasks;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.User;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Handlers.Users
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        private readonly IUserService _userService;
        public CreateUserHandler(IUserService userService){
            _userService = userService;
        }
        public async Task HandleAsync(CreateUser command)
        {
            var userId = Guid.NewGuid();
            var role = "user";
            await _userService.RegisterAsync(userId,command.Email,command.Username,command.Password,role);
        }
    }
}