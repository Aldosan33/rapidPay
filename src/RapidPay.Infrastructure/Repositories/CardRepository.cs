using Microsoft.EntityFrameworkCore;
using RapidPay.Domain.Entities;
using RapidPay.Domain.Repositories;
using RapidPay.Infrastructure.Data;

namespace RapidPay.Infrastructure.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly AppDbContext _context;

        public CardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Card> GetCard(int cardId)
        {
            return await _context.Cards.FirstOrDefaultAsync(x => x.Id == cardId);
        }

        public async Task<bool> CreateCard(Card card)
        {
            await _context.Cards.AddAsync(card);

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateCard(Card card)
        {
            _context.Cards.Update(card);

            return await _context.SaveChangesAsync() > 0;
        }
    }
}