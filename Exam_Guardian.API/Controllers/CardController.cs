using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Microsoft.AspNetCore.Mvc;

namespace Exam_Guardian.API.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard(CreateCardDTO createCardDto)
        {
            await _cardService.CreateCard(createCardDto);
            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCardById(decimal id)
        {
            var card = await _cardService.GetCardById(id);
            if (card == null)
                return NotFound();
            return Ok(card);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCard(decimal id, Card card)
        {
            if (id != card.CardId)
                return BadRequest();

            await _cardService.UpdateCard(card);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCard(decimal id)
        {
            await _cardService.DeleteCard(id);
            return NoContent();
        }

       
        [HttpPost]
        public async Task<IActionResult> WithdrawFromCard([FromBody] WithdrawCardDTO withdrawCardDto)
        {
            try
            {
                await _cardService.WithdrawFromCard(withdrawCardDto);
                return Ok();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
