using RapidPay.Domain.Entities;
using RapidPay.Domain.Models;

namespace RapidPay.Infrastructure.Providers
{
    public interface IAuthTokenProvider
    {
        TokenIdentity CreateAccessToken(User user);
    }
}