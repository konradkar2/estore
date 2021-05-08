namespace Store.Infrastructure.Commands
{
    public class PaginationCommandBase : ICommand 
    {
        public int PageNumber {get;set;}
    }
}