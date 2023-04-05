using RapidPay.Domain.Entities;

namespace RapidPay.Domain.Repositories
{
    public interface IPaymentRepository
    {
        Task<bool> CreatePayment(Payment payment);
    }
}