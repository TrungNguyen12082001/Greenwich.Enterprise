using Greenwich.CommonServices;
using Greenwich.CommonServices.Services;
using Greenwich.DataPersistence.Common;
using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.Models.Responses;
using Greenwich.WebService.IServices;

namespace Greenwich.WebService.Services
{
    public class UserService : IUserService
    {
        #region Constructor

        private readonly IGEWUnitOfWork _unitOfWork;
        private readonly IJwtHandler _jwtHandler;
        private readonly IEncrypter _encrypter;

        public UserService(IGEWUnitOfWork unitOfWork, IEncrypter encrypter)
        { 
            _unitOfWork = unitOfWork;
            _encrypter = encrypter;
        }

        #endregion

        public async Task<UserListResponse> GetALlUsersAsync()
        {
            var result = await _unitOfWork.UserRepository.GetAllUsers();
            return result;
        }


        public async Task<bool> CreateUserAsync(CreateUserRequest model)
        {
            if (await IsValidEmail(model.Email) == false)
            {
                throw new Exception("Email existed.");
            }
            var salt = _encrypter.GetSalt(model.Password);
            var encryptPassword = _encrypter.GetHash(model.Password, salt);

            var user = new User {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                RoleId = model.UserRoleId,
                DepartmentId = model.DepartmentId,
                Salt = salt,
                Password = encryptPassword,
                Avatar = ""
            };

            await _unitOfWork.UserRepository.InsertAsync(user);

            return await _unitOfWork.SaveChangeAsync() > 0;
        }

        private async Task<bool> IsValidEmail(string email)
        {
            var user = await _unitOfWork.UserRepository.GetOneAsync(x => x.Email == email);
            return user == null;
        }

        public async Task<bool> UpdateUserAsync(User model)
        {
            var userDTO =  await _unitOfWork.UserRepository.GetByIdAsync(model.Id);
            if (userDTO != null)
            {
                userDTO.FirstName = model.FirstName;
                userDTO.LastName = model.LastName;
                userDTO.RoleId = model.RoleId;
                userDTO.DepartmentId = model.DepartmentId;

                _unitOfWork.UserRepository.Update(userDTO);

                return await _unitOfWork.SaveChangeAsync() > 0;
            }

            return false;
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var userDTO = await _unitOfWork.UserRepository.GetByIdAsync(id);
            if (userDTO != null)
            {
                _unitOfWork.UserRepository.Delete(userDTO);
                return await _unitOfWork.SaveChangeAsync() > 0;
            }

            return false;
        }

    }
}
