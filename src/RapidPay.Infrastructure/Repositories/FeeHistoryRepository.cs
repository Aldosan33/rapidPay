using Microsoft.EntityFrameworkCore;
using RapidPay.Domain.Entities;
using RapidPay.Domain.Repositories;
using RapidPay.Infrastructure.Data;

namespace RapidPay.Infrastructure.Repositories
{
    public class FeeHistoryRepository : IFeeHistoryRepository
    {
        private readonly AppDbContext _context;

        public FeeHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FeeHistory> GetLastFeeHistory()
        {
            return await _context.FeeHistories
                .OrderByDescending(x => x.Id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> CreateFeeHistory(FeeHistory feeHistory)
        {
            await _context.FeeHistories.AddAsync(feeHistory);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}