using System.Threading.Tasks;
using Store.Infrastructure.Commands;
using Store.Infrastructure.Commands.Category;
using Store.Infrastructure.Services.Interfaces;

namespace Store.Infrastructure.Handlers.Category
{
    public class CreateCategoryHandler : ICommandHandler<CreateCategory>
    {
        private readonly IStoreManager _storeManager;
        public CreateCategoryHandler(IStoreManager storeManager)
        {
            _storeManager = storeManager;            
        }
        public async Task HandleAsync(CreateCategory command)
        {
            await _storeManager.CreateCategoryAsync(command.Id,command.Name);
        }
    }
}