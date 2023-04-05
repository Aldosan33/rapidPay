using RapidPay.Domain.Entities;

namespace RapidPay.Domain.Repositories
{
    public interface IFeeHistoryRepository
    {
        Task<FeeHistory> GetLastFeeHistory();

        Task<bool> CreateFeeHistory(FeeHistory feeHistory);
    }
}