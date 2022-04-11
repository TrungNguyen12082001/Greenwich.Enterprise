using Greenwich.EntityFramework.Entities;
using Greenwich.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greenwich.WebService.IServices
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> GetDepartmentsAsync();

        Task<bool> CreateNewDepartment(CreateDepartmentRequest model);
    }
}
