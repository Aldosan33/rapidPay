using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Domain.Models;
using RapidPay.Infrastructure.Services;

namespace RapidPay.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CardsController : ControllerBase
    {
        private readonly ICardService _cardService;

        public CardsController(ICardService cardService)
        {
            _cardService = cardService;
        }

        [HttpGet("{cardId:int}/balances")]
        public async Task<IActionResult> GetCardBalance([FromRoute] int cardId)
        {
            var cardBalance = await _cardService.GetCardBalance(cardId);

            return Ok(cardBalance);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCard([FromBody] CardForCreationDTO cardForCreationDTO)
        {
            var cardId = await _cardService.CreateCard(cardForCreationDTO);

            if (cardId == 0)
            {
                return BadRequest("Card could not be created");
            }

            return StatusCode(StatusCodes.Status201Created, new { Id = cardId });
        }
    }
}
