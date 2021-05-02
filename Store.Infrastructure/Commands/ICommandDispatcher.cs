using System.Threading.Tasks;

namespace Store.Infrastructure.Commands
{
    public interface ICommandDispatcher
    {
         Task DispatchAsync<T>(T command) where T: ICommand;
    }
}