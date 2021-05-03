using System.Threading.Tasks;


namespace Store.Core.Repositories
{
    //marker interface
    public interface IRepository
    {
        Task SaveChangesAsync();
        
    }
}