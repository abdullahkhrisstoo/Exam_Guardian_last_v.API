using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Repository
{
    public class CardRepository : ICardRepository
    {
        private readonly ModelContext _context;

        public CardRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task CreateCard(CreateCardDTO createCardDto)
        {
            var card = new Card
            {
                CardValue = createCardDto.CardValue,
                CardNumber = createCardDto.CardNumber,
                CardExpireDate = createCardDto.CardExpireDate,
                CardCvv = createCardDto.CardCvv,
                CardHolderName = createCardDto.CardHolderName
            };
            _context.Cards.Add(card);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCard(decimal id)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card != null)
            {
                _context.Cards.Remove(card);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Card> GetCardById(decimal id)
        {
            return await _context.Cards.FindAsync(id);
        }

        public async Task<List<Card>> GetAllCards()
        {
            return await _context.Cards.ToListAsync();
        }

        public async Task UpdateCard(Card card)
        {
            _context.Cards.Update(card);
            await _context.SaveChangesAsync();
        }

        public async Task DepositToCard(decimal id, decimal amount)
        {
            var card = await _context.Cards.FindAsync(id);
            if (card != null)
            {
                card.CardValue += amount;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> WithdrawFromCard(WithdrawCardDTO withdrawCardDto)
        {
            if (withdrawCardDto.CardInfoDTO is null) {
                throw new InvalidOperationException("Card not found");
            }

            var card = await _context.Cards.FirstOrDefaultAsync(c =>
                c.CardNumber == withdrawCardDto.CardInfoDTO.CardNumber &&
                c.CardExpireDate == withdrawCardDto.CardInfoDTO.CardExpireDate &&
                c.CardCvv == withdrawCardDto.CardInfoDTO.CardCvv &&
                c.CardHolderName == withdrawCardDto.CardInfoDTO.CardHolderName);

            if (card != null)
            {
                if (card.CardValue >= withdrawCardDto.AmountWithDraw)
                {
                    card.CardValue -= withdrawCardDto.AmountWithDraw;
                  return  await _context.SaveChangesAsync();
                }
                else
                {
                    throw new InvalidOperationException("Insufficient funds");
                }
            }
            else
            {
                throw new InvalidOperationException("Card not found");
            }
        }
    }
}
