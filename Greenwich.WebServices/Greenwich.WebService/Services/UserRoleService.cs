using Greenwich.DataPersistence.Common;
using Greenwich.EntityFramework.Entities;
using Greenwich.WebService.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenwich.WebService.Services
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IGEWUnitOfWork _unitOfWork;

        public UserRoleService(IGEWUnitOfWork unitOfWork)
        { 
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<UserRole>> GetUserRolesAsync()
        {
            var modelList = await _unitOfWork.UserRoleRepository.GetAsync();
            return modelList;
        }
    }
}
