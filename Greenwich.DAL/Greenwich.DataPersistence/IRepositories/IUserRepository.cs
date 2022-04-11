using Greenwich.DataPersistence.Common;
using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.Models.Responses;

namespace Greenwich.DataPersistence.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<UserResponse> GetUserByEmail(string email);

        Task<UserListResponse> GetAllUsers();
    }
}
