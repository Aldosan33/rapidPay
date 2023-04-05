using AutoMapper;
using RapidPay.Domain.Entities;
using RapidPay.Domain.Models;

namespace RapidPay.Application.Profiles
{
    public class PaymentProfile : Profile
    {
        public PaymentProfile()
        {
            // DTO -> Entity

            CreateMap<PaymentForCreationDTO, Payment>();
        }
    }
}
