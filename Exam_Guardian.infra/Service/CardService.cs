using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IRepository;
using Exam_Guardian.core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.infra.Service
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _cardRepository;

        public CardService(ICardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public async Task CreateCard(CreateCardDTO createCardDto)
        {
            await _cardRepository.CreateCard(createCardDto);
        }

        public async Task DeleteCard(decimal id)
        {
            await _cardRepository.DeleteCard(id);
        }

        public async Task<Card> GetCardById(decimal id)
        {
            return await _cardRepository.GetCardById(id);
        }

        public async Task<List<Card>> GetAllCards()
        {
            return await _cardRepository.GetAllCards();
        }

        public async Task UpdateCard(Card card)
        {
            await _cardRepository.UpdateCard(card);
        }

        public async Task DepositToCard(decimal id, decimal amount)
        {
            await _cardRepository.DepositToCard(id, amount);
        }

        public async Task WithdrawFromCard(WithdrawCardDTO withdrawCardDto)
        {
            await _cardRepository.WithdrawFromCard(withdrawCardDto);
        }
    }
}
