using Exam_Guardian.core.Data;
using Exam_Guardian.core.DTO;
using Exam_Guardian.core.IService;
using Exam_Guardian.core.Utilities.CalimHandler;
using Exam_Guardian.core.Utilities.UserRole;
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
        [CheckClaimsAttribute(UserRoleConstant.SAdmin)]

        public async Task<IActionResult> CreateCard(CreateCardDTO createCardDto)
        {
            await _cardService.CreateCard(createCardDto);
            return Ok();
        }

        [HttpGet("{id}")]
        //[CheckClaimsAttribute(UserRoleConstant.SAdmin)]


        public async Task<IActionResult> GetCardById(decimal id)
        {
            var card = await _cardService.GetCardById(id);
            if (card == null)
                return NotFound();
            return Ok(card);
        }

        [HttpPut("{id}")]
        [CheckClaimsAttribute(UserRoleConstant.SAdmin)]

        public async Task<IActionResult> UpdateCard(decimal id, Card card)
        {
            if (id != card.CardId)
                return BadRequest();

            await _cardService.UpdateCard(card);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [CheckClaimsAttribute(UserRoleConstant.SAdmin)]

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
