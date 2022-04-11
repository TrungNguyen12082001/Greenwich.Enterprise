namespace Greenwich.Models
{
    public class JsonWebToken
    {
        public string Token { get; set; }
        public long Expires { get; set; }
    }

    public interface IJwtOptions
    {
        string SecretKey { get; }
        int ExpiryMinutes { get; }
        string Issuer { get; }
    }

    public class JwtOptions : IJwtOptions
    {
        public string SecretKey { get; set; }
        public int ExpiryMinutes { get; set; }
        public string Issuer { get; set; }
    }
}
