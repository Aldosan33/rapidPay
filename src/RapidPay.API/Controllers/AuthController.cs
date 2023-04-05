using Microsoft.AspNetCore.Mvc;
using RapidPay.Domain.Models;
using RapidPay.Infrastructure.Providers;
using RapidPay.Infrastructure.Services;

namespace RapidPay.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IAuthTokenProvider _authTokenProvider;

        public AuthController(IAuthService authService, IAuthTokenProvider authTokenProvider)
        {
            _authService = authService;
            _authTokenProvider = authTokenProvider;
        }

        [HttpPost("sign-in")]
        public async Task<IActionResult> SignIn([FromBody] UserForSigningInDTO userForSigningInDTO)
        {
            var user = await _authService.SignIn(userForSigningInDTO);

            if (user == null)
            {
                return BadRequest("Username and/or Password are incorrect.");
            }

            var accessToken = _authTokenProvider.CreateAccessToken(user);

            return Ok(new
            {
                userId = user.Id,
                token = accessToken.Token,
                expiry = accessToken.Expiry,
                expiresIn = accessToken.ExpiresIn
            });
        }

        [HttpPost("sign-up")]
        public async Task<IActionResult> SignUp([FromBody] UserForSigningUpDTO userForSigningUpDTO)
        {
            var result = await _authService.SignUp(userForSigningUpDTO);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Message);
            }

            return StatusCode(StatusCodes.Status201Created);
        }
    }
}
