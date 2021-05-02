using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Store.Infrastructure.Commands;

namespace Store.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly ICommandDispatcher CommandDispatcher;       
        protected ApiControllerBase(ICommandDispatcher commandDispatcher){

            CommandDispatcher = commandDispatcher; 
        }
        
    }
}