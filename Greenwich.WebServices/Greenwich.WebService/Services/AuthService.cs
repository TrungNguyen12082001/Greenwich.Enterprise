using Greenwich.CommonServices;
using Greenwich.CommonServices.Services;
using Greenwich.DataPersistence.Common;
using Greenwich.Models;
using Greenwich.WebService.IServices;

namespace Greenwich.WebService.Services
{
    public class AuthService : IAuthService
    {
        #region Constructor

        private readonly IGEWUnitOfWork _unitOfWork;
        private readonly IEncrypter _encrypter;
        private readonly IJwtHandler _jwtHandler;

        public AuthService(IGEWUnitOfWork unitOfWork, IEncrypter encrypter, IJwtHandler jwtHandler)
        {
            _unitOfWork = unitOfWork;
            _encrypter = encrypter;
            _jwtHandler = jwtHandler;
        }

        #endregion


        public async Task<JsonWebToken> LoginAsync(LoginModel model)
        {
            var user = await _unitOfWork.UserRepository.GetUserByEmail(model.EmailAddress);

            if (user == null)
            {
                throw new Exception("Invalid credential.");
            }

            if (!ValidatePassword(user.Password, user.Salt, model.Password, _encrypter))
            {
                throw new Exception("Invalid credential.");
            }

            var token = _jwtHandler.Create(user);

            return token;
        }

        public bool ValidatePassword(string currentPassword, string salt, string loginPassword, IEncrypter encrypter) =>
            currentPassword.Equals(encrypter.GetHash(loginPassword, salt));
    }
}
