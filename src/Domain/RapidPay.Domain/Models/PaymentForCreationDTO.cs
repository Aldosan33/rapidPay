using System.ComponentModel.DataAnnotations;

namespace RapidPay.Domain.Models
{
    public class PaymentForCreationDTO
    {
        [Required]
        public int CardId { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Amount { get; set; }
    }
}