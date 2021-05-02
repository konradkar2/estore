

using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.User;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Api.Controllers
{
    public class UsersController : ApiControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(ICommandDispatcher commandDispatcher,
        IUserService userService) : base(commandDispatcher)
        {
            _userService = userService;            
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateUser command)
        {
            await CommandDispatcher.DispatchAsync(command);

            return Created($"users/{command.Email}",null);            
        }
        [HttpGet]
        public async Task<IActionResult> Browse() //TODO: Pagination
        {
            var users =  await _userService.BrowseAsync(0,100);
            return Ok(users);
        }
    }
}