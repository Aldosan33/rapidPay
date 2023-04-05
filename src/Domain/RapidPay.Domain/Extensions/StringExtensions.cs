namespace RapidPay.Domain.Extensions
{
    public static class StringExtensions
    {
        public static string Masked(this string source, int start, int count)
        {
            return source.Masked('*', start, count);
        }

        public static string Masked(this string source, char maskValue, int start, int count)
        {
            var firstPart = source[..start];
            var lastPart = source[(start + count)..];
            var middlePart = new string(maskValue, count);

            return firstPart + middlePart + lastPart;
        }
    }
}