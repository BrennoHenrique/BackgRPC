using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BackgRPC.Filters.Settings
{
    public class SettingsJwt
    {
        private const string SecretKey = "ad1fc879ac60aa541cad9d7b5cf880d2d9b204a3cd72823a6fa4a727bfcbdbbc";

        public static byte[] SecretKeyInBytes => Encoding.UTF8.GetBytes(SecretKey);

        public static TokenValidationParameters TokenValidationParameters()
            => new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(SecretKeyInBytes),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
    }
}