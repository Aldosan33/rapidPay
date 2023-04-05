using RapidPay.Domain.Entities;

namespace RapidPay.Domain.Repositories
{
    public interface ICardRepository
    {
        Task<Card> GetCard(int cardId);

        Task<bool> CreateCard(Card card);

        Task<bool> UpdateCard(Card card);
    }
}