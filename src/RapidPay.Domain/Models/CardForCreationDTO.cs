using RapidPay.Domain.Attributes;
using System.ComponentModel.DataAnnotations;

namespace RapidPay.Domain.Models
{
    public class CardForCreationDTO : IValidatableObject
    {
        [Required]
        [MinLength(15)]
        [MaxLength(15)]
        [RegularExpression("([1-9][0-9]*)", ErrorMessage = "Card Number must contain only digits.")]
        public string Number { get; set; }

        [Required]
        public string Holder { get; set; }

        [Required]
        [Range(1, 12, ErrorMessage = "Expiration Month must be valid.")]
        public int ExpirationMonth { get; set; }

        [Required]
        [YearExpiration(ErrorMessage = "Expiration Year must be valid.")]
        public int ExpirationYear { get; set; }

        [Required]
        [Range(100, 999, ErrorMessage = "CVV must contain 3 digits.")]
        public int Cvv { get; set; }

        [Required]
        public decimal BalanceAmount { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var expirationDate = new DateTime(ExpirationYear, ExpirationMonth, 1);
            var today = DateTime.Today;

            if (expirationDate < today)
            {
                yield return new ValidationResult("A valid expiration year and month should be specified");
            }

            var holderValidation = Holder.All(c => char.IsLetter(c) || c == ' ');

            if (!holderValidation)
            {
                yield return new ValidationResult("Card Holder must contain only letters.");
            }
        }
    }
}