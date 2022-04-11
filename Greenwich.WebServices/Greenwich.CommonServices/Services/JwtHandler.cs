using Greenwich.Models;
using Greenwich.Models.Responses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Greenwich.CommonServices.Services
{
    public interface IJwtHandler
    {
        JsonWebToken Create(UserResponse user);

        string CreateExternalApiToken(string companyName);

        bool IsValidExternalApiToken(string token, string companyName);
    }

    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        private readonly JwtOptions _options;

        private readonly SecurityKey _issuerSigninKey;

        private readonly SigningCredentials _signingCredentials;

        private readonly JwtHeader _jwtHeader;

        private readonly TokenValidationParameters _tokenValidationParameters;

        public JwtHandler(IOptions<JwtOptions> options)
        {
            _options = options.Value;
            _issuerSigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey));
            _signingCredentials = new SigningCredentials(_issuerSigninKey, SecurityAlgorithms.HmacSha256);
            _jwtHeader = new JwtHeader(_signingCredentials);
            _tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false,
                ValidIssuer = _options.Issuer,
                IssuerSigningKey = _issuerSigninKey
            };
        }

        public JsonWebToken Create(UserResponse user)
        {
            var nowUtc = DateTime.UtcNow;
            var expires = nowUtc.AddMinutes(_options.ExpiryMinutes);
            var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
            var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);
            var now = (long)(new TimeSpan(nowUtc.Ticks - centuryBegin.Ticks).TotalSeconds);
            var payLoad = new JwtPayload(){
                {"userId", user.UserId},
                {"email", user.Email},
                {"userName", user.FullName},
                {"firstName", user.FirstName},
                {"lastName", user.LastName},
                {"role", new string[]{ user.RoleName } },                
                {"avatarUrl", user.AvatarUrl},
                {"depatmentId", user.DepartmentId },
                {"exp", exp},
                {"iat", now},
                {"iss", _options.Issuer},
            };

            var jwt = new JwtSecurityToken(_jwtHeader, payLoad);
            var token = _jwtSecurityTokenHandler.WriteToken(jwt);

            return new JsonWebToken()
            {
                Token = token,
                Expires = exp
            };
        }

        public string CreateExternalApiToken(string companyName)
        {
            var nowUtc = DateTime.UtcNow;
            var expires = nowUtc.AddYears(1);
            var centuryBegin = new DateTime(1970, 1, 1).ToUniversalTime();
            var exp = (long)(new TimeSpan(expires.Ticks - centuryBegin.Ticks).TotalSeconds);

            var payLoad = new JwtPayload {
                { "iss", companyName },
                { "exp", exp }
            };
            var jwt = new JwtSecurityToken(_jwtHeader, payLoad);
            var token = _jwtSecurityTokenHandler.WriteToken(jwt);
            return token;
        }

        public bool IsValidExternalApiToken(string token, string companyName)
        {
            var validationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidIssuer = companyName,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_options.SecretKey))
            };

            try
            {
                _jwtSecurityTokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);
                return true;
            }
            catch
            {
                return false;
            }
        }


    }
}
