using RapidPay.Domain.Entities;
using RapidPay.Domain.Repositories;
using RapidPay.Infrastructure.Data;

namespace RapidPay.Infrastructure.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly AppDbContext _context;

        public PaymentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreatePayment(Payment payment)
        {
            await _context.Payments.AddAsync(payment);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}