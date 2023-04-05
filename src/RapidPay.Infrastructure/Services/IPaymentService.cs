using RapidPay.Domain.Models;
using RapidPay.Domain.Validations;

namespace RapidPay.Infrastructure.Services
{
    public interface IPaymentService
    {
        Task<ValidationMessage> CreatePayment(PaymentForCreationDTO paymentForCreationDTO);
    }
}