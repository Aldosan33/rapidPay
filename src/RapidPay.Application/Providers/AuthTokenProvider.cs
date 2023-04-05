using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using RapidPay.Domain.Entities;
using RapidPay.Domain.Models;
using RapidPay.Infrastructure.Providers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RapidPay.Application.Providers
{
    public class AuthTokenProvider : IAuthTokenProvider
    {
        private readonly IConfiguration _config;

        public AuthTokenProvider(IConfiguration config)
        {
            _config = config;
        }

        public TokenIdentity CreateAccessToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value));
            
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512Signature);
            
            var accessExpireSeconds = _config.GetSection("Jwt:AccessExpireSeconds").Value;

            var accessTokenExpiry = DateTime.Now.AddSeconds(double.Parse(accessExpireSeconds));

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            var jwt = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: accessTokenExpiry,
                signingCredentials: credentials);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return new TokenIdentity
            {
                Token = accessToken,
                Expiry = accessTokenExpiry,
                ExpiresIn = int.Parse(accessExpireSeconds)
            };
        }
    }
}