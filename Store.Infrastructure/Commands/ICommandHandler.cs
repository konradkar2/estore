using System.Threading.Tasks;

namespace Store.Infrastructure.Commands
{
    public interface ICommandHandler<T> where T: ICommand
    {
         Task HandleAsync(T command);
    }
}