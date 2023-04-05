namespace RapidPay.Domain.Models
{
    public class CardForBalanceListDTO
    {
        public string Number { get; set; }

        public string Holder { get; set; }

        public decimal BalanceAmount { get; set; }
    }
}
