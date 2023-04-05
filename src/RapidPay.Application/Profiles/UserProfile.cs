using AutoMapper;
using RapidPay.Domain.Entities;
using RapidPay.Domain.Models;

namespace RapidPay.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // DTO -> Entity

            CreateMap<UserForSigningUpDTO, User>();
        }
    }
}