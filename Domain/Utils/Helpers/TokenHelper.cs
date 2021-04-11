using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Domain.Models;

namespace Domain.Utils.Helpers
{
    public static class TokenHelper
    {
        public static String GenerateToken(UserModel user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            var key = Encoding.ASCII.GetBytes(CoreConstants.Settings.Secret)

            tokenHandler.CreateToken()
        }
    }
}