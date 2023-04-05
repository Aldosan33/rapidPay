using AutoMapper;
using RapidPay.Domain.Entities;
using RapidPay.Domain.Models;
using RapidPay.Domain.Repositories;
using RapidPay.Infrastructure.Services;

namespace RapidPay.Application.Services
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;
        private readonly IMapper _mapper;

        public CardService(ICardRepository cardRepository, IMapper mapper)
        {
            _cardRepository = cardRepository;
            _mapper = mapper;
        }

        public async Task<CardForBalanceListDTO> GetCardBalance(int cardId)
        {
            var cardBalance = await _cardRepository.GetCard(cardId);

            return _mapper.Map<CardForBalanceListDTO>(cardBalance);
        }

        public async Task<int> CreateCard(CardForCreationDTO cardForCreationDTO)
        {
            var card = _mapper.Map<Card>(cardForCreationDTO);

            await _cardRepository.CreateCard(card);

            return card.Id;
        }
    }
}
