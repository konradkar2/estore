namespace Store.Infrastructure.Queries
{
    public class PaginationQueryBase : IQuery
    {
        public int Page {get;set;}
    }
}