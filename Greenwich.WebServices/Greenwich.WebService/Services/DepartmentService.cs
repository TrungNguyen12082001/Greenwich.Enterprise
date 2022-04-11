using Greenwich.DataPersistence.Common;
using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using Greenwich.WebService.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenwich.WebService.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IGEWUnitOfWork _unitOfWork;

        public DepartmentService(IGEWUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            var modelList = await _unitOfWork.DepartmentRepository.GetAsync();
            return modelList;
        }

        public async Task<bool> CreateNewDepartment(CreateDepartmentRequest model)
        {
            var department = new Department { 
                Name = model.DepartmentName
            };

            await _unitOfWork.DepartmentRepository.InsertAsync(department);
            return await _unitOfWork.SaveChangeAsync() > 0;
        }
    }
}
