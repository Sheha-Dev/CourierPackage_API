using CourierPackage_API.Interfaces;
using CourierPackage_API.Models.Entities;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CourierPackage_API.Services
{
    public class TokenService:ITokenService
    {
        private readonly ITokenRepository _tokenRepository;
        private readonly IConfiguration _configuration;

        public TokenService(ITokenRepository tokenRepository,IConfiguration configuration)
        {
            _tokenRepository = tokenRepository;
            _configuration = configuration;
        }

        public async Task<(string AccessToken, bool success)> GenerateAccessToken(string UserId,IList<string> roles)
        {
            // add all details into token as claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, UserId.ToString()),
            };

            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!)
            );

            var credentials = new SigningCredentials(
                key,
                SecurityAlgorithms.HmacSha256
            );

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddMinutes(3),
                signingCredentials: credentials
            );


            return (new JwtSecurityTokenHandler().WriteToken(token), true);
        }

        public async Task<string> UpdateRefreshToken(string UserId, DateTime ExpDate, string TrnUser)
        {
            return await _tokenRepository.UpdateRefreshToken(UserId, ExpDate, TrnUser);
        }
        public async Task<bool> IsExpireRefreshToken(string UserId)
        {
            return await _tokenRepository.IsExpireRefreshToken(UserId);
        }
    }
}
