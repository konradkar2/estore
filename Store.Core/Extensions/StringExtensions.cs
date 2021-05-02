namespace Store.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool Empty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
       
    }
}