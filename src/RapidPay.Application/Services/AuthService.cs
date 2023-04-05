using AutoMapper;
using RapidPay.Domain.Entities;
using RapidPay.Domain.Models;
using RapidPay.Domain.Repositories;
using RapidPay.Domain.Validations;
using RapidPay.Infrastructure.Services;

namespace RapidPay.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<User> SignIn(UserForSigningInDTO userForSigningInDTO)
        {
            return await _userRepository.VerifyUser(userForSigningInDTO.Username, userForSigningInDTO.Password);
        }

        public async Task<ValidationMessage> SignUp(UserForSigningUpDTO userForSigningUpDTO)
        {
            var userExists = await _userRepository.UserExists(userForSigningUpDTO.Username);

            if (userExists)
            {
                return new ValidationMessage(false, "Username already exists.");
            }

            var user = _mapper.Map<User>(userForSigningUpDTO);

            await _userRepository.CreateUser(user, userForSigningUpDTO.Password);

            return new ValidationMessage(true, string.Empty);
        }
    }
}