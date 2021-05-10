using System.Threading.Tasks;

namespace Store.Infrastructure.Services.Interfaces
{
     public interface IDataInitializer : IService
    {
        Task SeedAsync();
    }
}