namespace Store.Infrastructure.Queries
{
    public class PaginationQueryBase : IQuery
    {
        public int PageNumber {get;set;}
    }
}