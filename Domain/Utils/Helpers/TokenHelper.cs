using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Domain.Constants;
using Domain.Models;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Utils.Helpers
{
    public static class TokenHelper
    {
        public static String GenerateToken(UserModel user)
        {
            JwtSecurityTokenHandler tokenHandler = new();

            var key = Encoding.ASCII.GetBytes(CoreConstants.Settings.Secret);

            SecurityTokenDescriptor tokenDescriptor = new()
            {
                Subject = new(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.Role, user.Role.ToString())
                }),
                Expires = DateTimeOffset.UtcNow.AddHours(2).DateTime,
                SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}