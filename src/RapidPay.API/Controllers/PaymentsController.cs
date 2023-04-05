using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RapidPay.Domain.Models;
using RapidPay.Infrastructure.Services;

namespace RapidPay.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment([FromBody] PaymentForCreationDTO paymentForCreationDTO)
        {
            var result = await _paymentService.CreatePayment(paymentForCreationDTO);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
