namespace Store.Infrastructure.Commands
{
    public abstract class PaginationCommandBase : ICommand 
    {
        public int PageNumber {get;set;}
    }
}