using BookWebApi.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BookWebApi.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(User user)
        {
            // Step 1: Create claims (data inside token)
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,           user.UserName),
                new Claim(ClaimTypes.Role,           user.Role),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };

            // Step 2: Create signing key
            var key = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Step 3: Create token
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(
                                        Convert.ToDouble(_config["Jwt:ExpiryMinutes"])),
                signingCredentials: creds
            );

            // Step 4: Return token as string
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}