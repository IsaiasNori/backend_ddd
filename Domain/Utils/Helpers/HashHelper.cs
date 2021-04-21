using System;
using System.Security.Cryptography;
using System.Text;
using Domain.Constants;

namespace Domain.Utils.Helpers
{
    public static class HashHelper
    {
        public static String EncryptPassord(String password)
        {
            if (String.IsNullOrEmpty(password))
                return null;

            var key = CoreConstants.InternalKey;

            var encodedValue = Encoding.UTF8.GetBytes(password + key);

            return Convert.ToBase64String(encodedValue);
        }

        public static String DecryptPassord(String base64password)
        {
            if (String.IsNullOrEmpty(base64password))
                return null;

            var key = CoreConstants.InternalKey;

            var decodedValue = Convert.FromBase64String(base64password);

            var result = Encoding.UTF8.GetString(decodedValue);

            return result.Substring(0, result.Length - key.Length);
        }
    }
}