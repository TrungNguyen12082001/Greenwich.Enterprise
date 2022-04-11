using Greenwich.DataPersistence.Common;
using Greenwich.DataPersistence.IRepositories;
using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.Models.Responses;
using Microsoft.EntityFrameworkCore;

namespace Greenwich.DataPersistence.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public async Task<UserResponse> GetUserByEmail(string email)
        {
            var query = from item in _dbSet
                        join ritem in _dbContext.Set<UserRole>() on item.RoleId equals ritem.Id
                        where item.Email == email
                        select new UserResponse { 
                            UserId = item.Id,
                            UserRoleId = item.RoleId,
                            RoleName = ritem.Name,
                            Email = item.Email,
                            DepartmentId = item.DepartmentId,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            AvatarUrl = item.Avatar,
                            Password = item.Password,
                            Salt = item.Salt
                        };
            var model = await query.FirstOrDefaultAsync();
            return model;
        }

        public async Task<UserListResponse> GetAllUsers()
        {
            var query = from item in _dbSet
                        join ritem in _dbContext.Set<UserRole>() on item.RoleId equals ritem.Id
                        join ditem in _dbContext.Set<Department>() on item.DepartmentId equals ditem.Id
                        select new ShortUserResponse
                        {
                            UserId = item.Id,                            
                            RoleName = ritem.Name,
                            Email = item.Email,
                            Department = ditem.Name,
                            FirstName = item.FirstName,
                            LastName = item.LastName,
                            AvatarUrl = item.Avatar                            
                        };

            var model = new UserListResponse
            {
                UserList = await query.ToListAsync()
            };

            return model;
        }
    }
}
