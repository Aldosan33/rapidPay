using RapidPay.Domain.Models;

namespace RapidPay.Infrastructure.Services
{
    public interface ICardService
    {
        Task<CardForBalanceListDTO> GetCardBalance(int cardId);

        Task<int> CreateCard(CardForCreationDTO cardForCreationDTO);
    }
}