using Greenwich.CommonServices;
using Greenwich.Models;

namespace Greenwich.WebService.IServices
{
    public interface IAuthService
    {
        Task<JsonWebToken> LoginAsync(LoginModel model);

        bool ValidatePassword(string currentPassword, string salt, string loginPassword, IEncrypter encrypter);
    }
}
