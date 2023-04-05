using System.ComponentModel.DataAnnotations;

namespace RapidPay.Domain.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
    public class YearExpirationAttribute : RangeAttribute
    {
        public YearExpirationAttribute() : base(DateTime.Now.Year, int.MaxValue)
        {
        }
    }
}