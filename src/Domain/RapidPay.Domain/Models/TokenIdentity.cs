namespace RapidPay.Domain.Models
{
    public class TokenIdentity
    {
        public string Token { get; set; }

        public DateTime Expiry { get; set; }

        public int ExpiresIn { get; set; }
    }
}