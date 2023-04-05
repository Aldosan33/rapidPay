using RapidPay.Domain.Entities;
using RapidPay.Domain.Models;
using RapidPay.Domain.Validations;

namespace RapidPay.Infrastructure.Services
{
    public interface IAuthService
    {
        Task<User> SignIn(UserForSigningInDTO userForSigningInDTO);

        Task<ValidationMessage> SignUp(UserForSigningUpDTO userForSigningUpDTO);
    }
}