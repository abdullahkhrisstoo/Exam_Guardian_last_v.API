using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_Guardian.core.IRepository
{
    public interface ICardRepository
    {
        Task CreateCard(CreateCardDTO createCardDto);
        Task DeleteCard(decimal id);
        Task<Card> GetCardById(decimal id);
        Task<List<Card>> GetAllCards();
        Task UpdateCard(Card card);
        Task DepositToCard(decimal id, decimal amount);
        Task<int> WithdrawFromCard(WithdrawCardDTO withdrawCardDto); // Updated method
    }

}
