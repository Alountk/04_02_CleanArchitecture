using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Blog.Core.Entities;
using Blog.Infrastructure.Services.Contracts;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Blog.Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateToken(DateTime actualDate, User user, TimeSpan validateTime)
        {
            var _expirationDate = actualDate.Add(validateTime);
            var _claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Name, $"{user.FirstName} {user.LastName}"),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat,
                    new DateTimeOffset(actualDate).ToUniversalTime().ToUnixTimeSeconds().ToString(),
                    ClaimValueTypes.Integer64
                ),
                new Claim(ClaimTypes.Role, user.IsAdmin ? "Admin" : "User")
            };

            var _signingCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt:Key").Value)),
                    SecurityAlgorithms.HmacSha256Signature
            );

            var _Payload = new JwtPayload(
                issuer: _configuration.GetSection("Jwt:Issuer").Value,
                audience: _configuration.GetSection("Jwt:Audience").Value,
                claims: _claims,
                notBefore: DateTime.UtcNow,
                expires: _expirationDate
            );

            var _Header = new JwtHeader(_signingCredentials);
            var _Token = new JwtSecurityToken(
                _Header,
                _Payload
            );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}