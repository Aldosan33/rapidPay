using AutoMapper;
using RapidPay.Domain.Entities;
using RapidPay.Domain.Extensions;
using RapidPay.Domain.Models;

namespace RapidPay.Application.Profiles
{
    public class CardProfile : Profile
    {
        public CardProfile()
        {
            // Entity -> DTO

            CreateMap<Card, CardForBalanceListDTO>()
                .ForMember(dest => dest.Number,
                           opt => opt.MapFrom(src => src.Number.Masked(0, src.Number.Length - 4)));

            // DTO -> Entity

            CreateMap<CardForCreationDTO, Card>();
        }
    }
}
