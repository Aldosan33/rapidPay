using Microsoft.Extensions.Caching.Memory;
using RapidPay.Infrastructure.Services;

namespace RapidPay.Application.Services
{
    public class FeeExchangeService : IFeeExchangeService
    {
        private readonly IMemoryCache _cache;

        private const string Key = "FeeExchangeKey";

        public FeeExchangeService(IMemoryCache cache)
        {
            _cache = cache;
        }

        public decimal GetFeeExchange()
        {
            if (_cache.Get(Key) != null)
            {
                return (decimal)_cache.Get(Key);
            }
            else
            {
                var feeExchange = GetRandomFeeExchange();
                SaveCache(feeExchange);
                
                return feeExchange;
            }
        }

        private void SaveCache(decimal feeExchange)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions().SetAbsoluteExpiration(TimeSpan.FromHours(1));
            
            _cache.Set(Key, feeExchange, cacheEntryOptions);
        }

        private static decimal GetRandomFeeExchange()
        {
            var random = (decimal)(new Random().NextDouble() * 2);

            return decimal.Round(random, 2);
        }
    }
}