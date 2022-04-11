using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.Models.Responses;

namespace Greenwich.WebService.IServices
{
    public interface IUserService
    {
        Task<UserListResponse> GetALlUsersAsync();
        Task<bool> CreateUserAsync(CreateUserRequest model);
        Task<bool> UpdateUserAsync(User model);
        Task<bool> DeleteUserAsync(int userId);
    }
}
