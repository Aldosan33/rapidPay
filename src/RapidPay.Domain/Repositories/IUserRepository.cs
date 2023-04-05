using RapidPay.Domain.Entities;

namespace RapidPay.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> CreateUser(User user, string password);

        Task<bool> UserExists(string username);

        Task<User> VerifyUser(string username, string password);
    }
}