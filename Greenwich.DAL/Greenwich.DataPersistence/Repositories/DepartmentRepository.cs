using Greenwich.DataPersistence.Common;
using Greenwich.DataPersistence.IRepositories;
using Greenwich.EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace Greenwich.DataPersistence.Repositories
{
    public class DepartmentRepository : Repository<Department>, IDepartmentRepository
    {
        public DepartmentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
