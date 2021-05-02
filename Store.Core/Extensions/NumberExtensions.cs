namespace Store.Core.Extensions
{
    public static class NumberExtensions
    {
        public static bool IsNegative(this int v)
            => v < 0;
        public static bool IsNegative(this double v)
            => v < 0d;
        public static bool IsNegative(this decimal v)
            => v < 0m;
    }
}